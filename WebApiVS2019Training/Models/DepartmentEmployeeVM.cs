using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiVS2019Training.Models
{
    public class DepartmentEmployeeVM
    {
        public int DepId { get; set; }
        public int EmpId { get; set; }
        public string DeptName { get; set; }
        public string EmpFirstName { get; set; }
        public string EmpMiddleName { get; set; }
        public int EmpAge { get; set; }
    }
}
