using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace SaleWebMvc.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="{0} Required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage ="{0} Name size should be between {2} and {1}")]
        public string Name { get; set; }
        [Required(ErrorMessage = "{0} Required")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Required(ErrorMessage = "{0} Required")]
        [Range(100,50000, ErrorMessage ="{0} must be from {1} to {2}")]
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }

        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller()
        {

        }

        public Seller(int id, string name, string email, DateTime date, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            
            Date = date;
            
            BaseSalary = baseSalary;
            Department = department;
        }


        public void AddSales(SalesRecord salesRecord)
        {
            Sales.Add(salesRecord);
        }
        public void RemoveSale(SalesRecord salesRecord)
        {
            Sales.Remove(salesRecord);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Sales.Where(date => date.Date >= initial && date.Date <= final).Sum(amount => amount.Amount);
        }
    }
}
