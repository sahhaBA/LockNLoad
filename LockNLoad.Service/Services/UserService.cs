using AutoMapper;
using LockNLoad.Model.Requests;
using LockNLoad.Model.Responses;
using LockNLoad.Model.SearchObjects;
using LockNLoad.Service.Contexts;
using LockNLoad.Service.Entities;
using LockNLoad.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
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

            if (hash != entity.PasswordHash)
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

    }
}
