using LockNLoad.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockNLoad.Service.Interfaces
{
    public interface IKorisniciService : ICRUDService<User, Model.SearchObjects.UserSearchObject, Model.Requests.KorisniciInsertRequest, Model.Requests.KorisniciUpdateRequest>
    {
        public Task<User> Login(string username, string password);
    }
}
