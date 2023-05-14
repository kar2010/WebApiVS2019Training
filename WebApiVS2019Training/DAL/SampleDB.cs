using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiVS2019Training.Models;

namespace WebApiVS2019Training.DAL
{
    public class SampleDB:DbContext
    {
        public SampleDB(DbContextOptions<SampleDB>options):base(options)
        {

        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
