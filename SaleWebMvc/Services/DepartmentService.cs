using System;
using System.Collections.Generic;
using System.Linq;
using SaleWebMvc.Models;
using SaleWebMvc.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace SaleWebMvc.Services
{
    public class DepartmentService
    {
        public readonly SaleWebMvcContext _context;
        public DepartmentService(SaleWebMvcContext context)
        {
            _context = context; 
        }
        public async Task<List<Department>> FindAllAsysc()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
