using System;
using System.Collections.Generic;
using System.Linq;
using SaleWebMvc.Models;
using SaleWebMvc.Data;
namespace SaleWebMvc.Services
{
    public class DepartmentService
    {
        public readonly SaleWebMvcContext _context;
        public DepartmentService(SaleWebMvcContext context)
        {
            _context = context; 
        }
        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
