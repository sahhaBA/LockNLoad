﻿using LockNLoad.Model.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LockNLoad.Service.Interfaces
{
    public interface IDashboardService
    {
        Task<DashboardResponse> GetDashboardDataAsync();
    }
}
