using JBlog.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace JBlog.Data
{
    public class JBlogDbContext : DbContext
    {
        public JBlogDbContext(DbContextOptions<JBlogDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasQueryFilter(c => !c.IsDeleted);

            base.OnModelCreating(modelBuilder);
        }
        // 重写 SaveChanges
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            {
                //自动修改 CreateTime,UpdateTime
                var entityEntries = ChangeTracker.Entries().ToList();
                foreach (var entry in entityEntries)
                {
                    if (entry.State == EntityState.Added)
                        Entry(entry.Entity).Property(nameof(EntityBase.CreateOn)).CurrentValue = DateTime.Now;

                    if (entry.State == EntityState.Modified)
                        Entry(entry.Entity).Property(nameof(EntityBase.UpdateOn)).CurrentValue = DateTime.Now;
                }
                return await base.SaveChangesAsync(cancellationToken);
            }

        }


        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}
