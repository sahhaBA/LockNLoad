using LockNLoad.Model.SearchObjects;
using LockNLoad.Service.Entities;

namespace LockNLoad.Service.Interfaces
{
    public interface IUserService : ICRUDService<User, UserSearchObject, Model.Requests.KorisniciInsertRequest, Model.Requests.KorisniciUpdateRequest>
    {
        public Task<User> Login(string username, string password);
    }
}
