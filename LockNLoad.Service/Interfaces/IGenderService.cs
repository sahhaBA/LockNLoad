using LockNLoad.Model.Requests;
using LockNLoad.Model.Responses;
using LockNLoad.Model.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockNLoad.Service.Interfaces
{
    public interface IGenderService : ICRUDService<GenderResponse, GenderSearchObject, GenderInsertRequest, GenderUpdateRequest>
    {

    }
}
