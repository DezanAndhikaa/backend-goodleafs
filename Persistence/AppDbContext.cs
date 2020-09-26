using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interface;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Persistence {
    public class AppDbContext : DbContext, IAppDbContext {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base (options) { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<ProductGL> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<DetailOrder> DetailOrders { get; set; }
        public DbSet<ReviewsProduct> ReviewsProducts { get; set; }

        public async Task ExecuteSqlRawAsync (string sqlQuery, CancellationToken cancellationToken = default (CancellationToken)) {
            await base.Database.ExecuteSqlRawAsync (sqlQuery, cancellationToken);
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfigurationsFromAssembly (typeof (AppDbContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync (bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default (CancellationToken)) {
            var result = await base.SaveChangesAsync (acceptAllChangesOnSuccess, cancellationToken);
            return 1;
        }
    }
}