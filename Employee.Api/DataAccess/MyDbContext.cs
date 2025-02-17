using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employee.Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Employee.Api.DataAccess
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options):base(options)
        {
            
        }

        public DbSet<Emp> Employee{get;set;}
          public DbSet<Manager> Manager{get;set;}

    }
}