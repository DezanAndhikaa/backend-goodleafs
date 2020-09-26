using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interface {
    public interface IAppDbContext {
        DbSet<Admin> Admins { get; set; }
        DbSet<Article> Articles { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Courier> Couriers { get; set; }
        DbSet<Discount> Discounts { get; set; }
        DbSet<ProductGL> Products { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<DetailOrder> DetailOrders { get; set; }
        DbSet<ReviewsProduct> ReviewsProducts { get; set; }

        Task<int> SaveChangesAsync (bool acceptAllChangesOnSuccess, CancellationToken cancellationToken);

    }
}