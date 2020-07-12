using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project1.Domain.Model;

namespace ProjectOne.Data
{
    public class ProjectOneContext : DbContext
    {
        public ProjectOneContext (DbContextOptions<ProjectOneContext> options)
            : base(options)
        {
        }

        public DbSet<Project1.Domain.Model.Customer> Customer { get; set; }
    }
}
