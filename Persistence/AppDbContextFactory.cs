using Microsoft.EntityFrameworkCore;

namespace Persistence {
    public class AppDbContextFactory : DesignTimeDbContextFactoryBase<AppDbContext> {
        /// <summary>
        /// CreateNewInstance
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        protected override AppDbContext CreateNewInstance (DbContextOptions<AppDbContext> options) {
            return new AppDbContext (options);
        }

    }
}