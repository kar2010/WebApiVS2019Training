using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiVS2019Training.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmpFirstName { get; set; }
        public string EmpMiddleName { get; set; }
        public int EmpAge { get; set; }
        [ForeignKey("Department")]
        public int DeptId { get; set; }
        public Department Department { get; set; }
    }
}
