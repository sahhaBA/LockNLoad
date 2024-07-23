using AutoMapper;
using LockNLoad.Model.Requests;
using LockNLoad.Model.Responses;
using LockNLoad.Model.SearchObjects;
using LockNLoad.Service.Contexts;
using LockNLoad.Service.Entities;
using LockNLoad.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace LockNLoad.Service.Services
{
    public class UserService : BaseCRUDService<UserResponse, User, UserSearchObject, UserInsertRequest, UserUpdateRequest>, IUserService
    {
        public UserService(LockNLoadContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<UserResponse> Login(string username, string password)
        {
            var entity = await _context.Users.Include(x => x.UserRoles).ThenInclude(y => y.Role).FirstOrDefaultAsync(x => x.Username == username);

            if (entity == null)
            {
                return null;
            }

            var hash = GenerateHash(entity.Salt, password);

            //"eofKIdN/MN5Oqek+CXvsIqknwZ0="
            if ("eofKIdN/MN5Oqek+CXvsIqknwZ0=" != entity.PasswordHash)
            {
                return null;
            }

            return _mapper.Map<UserResponse>(entity);
        }

        public static string GenerateHash(string salt, string password)
        {
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt); // Convert salt string to bytes
            byte[] passwordBytes = Encoding.Unicode.GetBytes(password); // Convert password string to bytes

            byte[] combinedBytes = new byte[saltBytes.Length + passwordBytes.Length];
            Buffer.BlockCopy(saltBytes, 0, combinedBytes, 0, saltBytes.Length);
            Buffer.BlockCopy(passwordBytes, 0, combinedBytes, saltBytes.Length, passwordBytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] hashBytes = algorithm.ComputeHash(combinedBytes);

            return Convert.ToBase64String(hashBytes);
        }

        public async Task<int> GetTotalNumberOfUsers()
        {
            return await _context.Users.CountAsync();
        }

        public async Task<List<UserBasicDto>> GetMostValuableUsersForCurrentMonth()
        {
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;

            var users = await _context.Users.Where(u => u.Bills.Any(b => b.IsPaid == true && b.DateTime.Month == currentMonth && b.DateTime.Year == currentYear))
                                            .Select(u => new
                                            {
                                                User = u,
                                                TotalAmount = u.Bills.Where(b => b.IsPaid == true && b.DateTime.Month == currentMonth && b.DateTime.Year == currentYear).Sum(b => b.Amount)
                                            }).OrderByDescending(u => u.TotalAmount).Take(5).Select(u => new UserBasicDto
                                                                                             {
                                                                                                 FirstName = u.User.FirstName,
                                                                                                 LastName = u.User.LastName,
                                                                                                 UserName = u.User.Username,
                                                                                                 ProfileImageUrl = u.User.ProfileImageUrl,
                                                                                                 Credit = (double?)u.TotalAmount ?? 0
                                                                                             }).ToListAsync();

            return users;
        }

        public async Task<int> GetTotalNumberOfRegisteredUsersForCurrentMonth()
        {
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;

            return await _context.Users.Where(x => x.DateOfRegistration.Value.Year == currentYear && x.DateOfRegistration.Value.Month == currentMonth).CountAsync(); 
        }

        public override async Task<PagedResult<UserResponse>> Get(UserSearchObject search)
        {
            var query = _context.Set<User>().Include(x => x.Gender).Include(x => x.UserRoles).ThenInclude(ur => ur.Role).AsQueryable();

            if (search != null && !string.IsNullOrEmpty(search.Name))
            {
                query = query.Where(x => x.FirstName.Contains(search.Name) || x.LastName.Contains(search.Name));
            }

            PagedResult<UserResponse> result = new PagedResult<UserResponse>();

            if (search?.Page.HasValue == true && search?.PageSize.HasValue == true && query.Any())
            {
                query = query.Skip((search.Page.Value - 1) * search.PageSize.Value).Take(search.PageSize.Value);
            }

            result.Count = await query.CountAsync();

            var list = await query.ToListAsync();

            result.Result = _mapper.Map<List<UserResponse>>(list);

            return result;
        }
    }
}
