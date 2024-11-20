using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Core;
using Warehouse.Domain.Entities;

namespace Warehouse.DAL
{
    public class WarehouseDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!; // допускающий значение NULL
        public WarehouseDbContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=warehouse.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.StoragePlace)
                .HasConversion(
                    sp => sp.ToString(), // Преобразование в строку для БД
                    str => StoragePlaceConverter.ToStoragePlace(str) // Преобразование из строки в StoragePlace
                );
        }


    }
}
