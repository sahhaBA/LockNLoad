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
using System.Text;
using System.Threading.Tasks;

namespace LockNLoad.Service.Services
{
    public class BillService : BaseCRUDService<BillResponse, Bill, BillSearchObject, BillInsertRequest, BillUpdateRequest>, IBillService
    {
        public BillService(LockNLoadContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<double?> GetCurrentMonthRevenue()
        {
            var currentMonth = DateTime.Now.Month;
            var currentYear = DateTime.Now.Year;

            return await _context.Bills.Where(x => x.IsPaid == true && x.DateTime.Month == currentMonth && x.DateTime.Year == currentYear).SumAsync(y => (double?)y.Amount);
        }

        public async Task<double?> GetTotalRevenue()
        {
            return await _context.Bills.Where(x => x.IsPaid == true).SumAsync(y => (double?)y.Amount);
        }
    }
}
