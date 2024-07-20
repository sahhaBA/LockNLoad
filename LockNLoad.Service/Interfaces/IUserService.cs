using LockNLoad.Model.Requests;
using LockNLoad.Model.Responses;
using LockNLoad.Model.SearchObjects;
using LockNLoad.Service.Entities;

namespace LockNLoad.Service.Interfaces
{
    public interface IUserService : ICRUDService<UserResponse, UserSearchObject, UserInsertRequest, UserUpdateRequest>
    {
        Task<List<UserBasicDto>> GetMostValuableUsersForCurrentMonth();
        Task<int> GetTotalNumberOfRegisteredUsersForCurrentMonth();
        Task<int> GetTotalNumberOfUsers();
        Task <List<UserResponse>> GetUserDataAsync(UserSearchObject search);
        public Task<UserResponse> Login(string username, string password);
    }
}
