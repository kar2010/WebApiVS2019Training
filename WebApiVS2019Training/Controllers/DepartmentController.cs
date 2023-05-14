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
    public class DepartmentController : ControllerBase
    {
        private readonly SampleDB sampleDB;

        public DepartmentController(SampleDB sampleDB)
        {
            this.sampleDB = sampleDB;
        }
        public async Task<IEnumerable<Department>> Get()
        {
            var depts = sampleDB.Departments.ToList();
            return depts;
        }
        [HttpPost]
        public IActionResult Post([FromForm] Department department)
        {
            try
            {
                if (department.DeptName == null)
                {
                    return NotFound();
                }
                else
                {
                    Department dep = new Department
                    {
                        DeptName = department.DeptName
                    };
                    sampleDB.Departments.Add(dep);
                    sampleDB.SaveChanges();
                    return Ok(dep);
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        [HttpPut]
        public IActionResult Put([FromForm] Department department)
        {
            try
            {
                if (department.Id == 0)
                {
                    return NotFound();
                }
                else
                {
                    Department dep = sampleDB.Departments.Find(department.Id);// new Department
                    dep.DeptName = department.DeptName;
                    sampleDB.Departments.Update(dep);
                    sampleDB.SaveChanges();
                    return Ok(dep);
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
                    Department dep = sampleDB.Departments.Find(id);// new Department
                    
                    sampleDB.Departments.Remove(dep);
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
