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

        public DbSet<Project1.Domain.Model.CustomerViewModel> CustomerViewModel { get; set; }

        public DbSet<Project1.Domain.Model.InventoryViewModel> InventoryViewModel { get; set; }

        public DbSet<Project1.Domain.Model.OrderHistoryViewModel> OrderHistoryViewModel { get; set; }

        public DbSet<Project1.Domain.Model.ProductViewModel> ProductViewModel { get; set; }

        public DbSet<Project1.Domain.Model.StoreLocationViewModel> StoreLocationViewModel { get; set; }

        public DbSet<Project1.Domain.Model.StoreOrderViewModel> StoreOrderViewModel { get; set; }
    }
}
