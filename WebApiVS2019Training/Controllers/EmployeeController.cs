using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiVS2019Training.DAL;
using WebApiVS2019Training.Models;

namespace WebApiVS2019Training.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly SampleDB sampleDB;

        public EmployeeController(SampleDB sampleDB)
        {
            this.sampleDB = sampleDB;
        }
        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {
            var empts = await sampleDB.Employees.Include(e=>e.Department).ToListAsync();
            return empts;
        }
        [HttpGet]
        [Route("{id:employee}")]
        public async Task<Employee> Get(int id=0)
        {
            var empts =await sampleDB.Employees.Include(e => e.Department).SingleOrDefaultAsync(x=>x.Id==id);
            return empts;
        }
        [HttpPost]
        public IActionResult Post([FromForm] Employee employee)
        {
            try
            {
                if (employee.EmpFirstName == null)
                {
                    return NotFound();
                }
                else
                {
                    Employee emp = new Employee
                    {
                        EmpFirstName = employee.EmpFirstName,
                        EmpAge=employee.EmpAge,
                        DeptId=employee.DeptId,
                        EmpMiddleName=employee.EmpMiddleName
                    };
                    sampleDB.Employees.Add(emp);
                    sampleDB.SaveChanges();
                    return Ok(emp);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPut]
        public IActionResult Put([FromForm] Employee employee)
        {
            try
            {
                if (employee.Id == 0)
                {
                    return NotFound();
                }
                else
                {
                    Employee emp = sampleDB.Employees.Find(employee.Id);// new Employee
                    emp.EmpMiddleName = employee.EmpMiddleName;
                    emp.EmpAge = employee.EmpAge;
                    emp.EmpFirstName = employee.EmpFirstName;
                    emp.DeptId = employee.DeptId;
                    sampleDB.Employees.Update(emp);
                    sampleDB.SaveChanges();
                    return Ok(emp);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id=0)
        {
            try
            {
                if (id == 0)
                {
                    return NotFound();
                }
                else
                {
                    Employee emp = sampleDB.Employees.Find(id);// new Employee
                    
                    sampleDB.Employees.Remove(emp);
                    sampleDB.SaveChanges();
                    return Ok("Successfully deleted");
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
