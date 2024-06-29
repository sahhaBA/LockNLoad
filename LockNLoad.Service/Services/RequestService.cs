using AutoMapper;
using LockNLoad.Model.Requests;
using LockNLoad.Model.Responses;
using LockNLoad.Model.SearchObjects;
using LockNLoad.Service.Contexts;
using LockNLoad.Service.Entities;
using LockNLoad.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockNLoad.Service.Services
{
    public class RequestService : BaseCRUDService<RequestResponse, Request, RequestSearchObject, RequestInsertRequest, RequestUpdateRequest>, IRequestService
    {
        public RequestService(LockNLoadContext context, IMapper mapper)
            : base(context, mapper)
        {
        }


    }
}
