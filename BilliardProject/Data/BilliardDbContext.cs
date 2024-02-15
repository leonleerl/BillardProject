using BilliardProject.Common;
using BilliardProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace BilliardProject.Data
{
    public class BilliardDbContext : DbContext
    {

        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<LogModel> Logs { get; set; }
        public DbSet<User> Users { get; set; }
        public string? DbPath { get; set; }

        public BilliardDbContext()
        {
            DbPath = DataBlock.Instance.DbPath;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }

    }
}
