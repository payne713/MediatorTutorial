using Microsoft.EntityFrameworkCore;
using Project.Domain.AggregateModels;
using Project.Domain.SeedWorks.EntityConfigurations;

namespace Project.Domain.SeedWorks
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<AppUser> AppUsers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 自定义 AppUser 表创建规则
            modelBuilder.ApplyConfiguration(new AppUserConfiguration());
        }
    }
}