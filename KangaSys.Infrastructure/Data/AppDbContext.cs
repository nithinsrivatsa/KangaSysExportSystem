// <copyright file="AppDbContext.cs" company="KangaSys">
//   Copyright 2025 KangaSys. All rights reserved
// </copyright>

namespace KangaSys.Infrastructure.Data
{
    using KangaSys.Domain.Entities;
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        public DbSet<ClientReportData> ClientReportData { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientReportData>().HasKey(e => e.Id);
            modelBuilder.Entity<ClientReportData>().HasIndex(e => e.ClientId);
            modelBuilder.Entity<ClientReportData>().HasIndex(e => e.Region);
            modelBuilder.Entity<ClientReportData>().HasIndex(e => e.ReportDate);
        }
    }
}
