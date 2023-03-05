using JBlog.Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace JBlog.Data
{
    public class JBlogDbContext : DbContext
    {
        public JBlogDbContext(DbContextOptions<JBlogDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
    }
}
