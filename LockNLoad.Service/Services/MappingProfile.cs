﻿using AutoMapper;
using LockNLoad.Model.Requests;
using LockNLoad.Model.Responses;
using LockNLoad.Service.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockNLoad.Service.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserResponse>();
            CreateMap<UserInsertRequest, User>();
            CreateMap<UserUpdateRequest, User>();

            CreateMap<UserRole, UserRoleResponse>();

            CreateMap<Role, RoleResponse>();
            CreateMap<RoleInsertRequest, Role>();
            CreateMap<RoleUpdateRequest, Role>();
        }
    }
}
