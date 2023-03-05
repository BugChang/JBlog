using JBlog.Core.Entity;
using JBlog.Core.Interfaces;

namespace JBlog.Data.Repository
{
    public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
    {
        public CategoryRepository(JBlogDbContext dbContext) : base(dbContext)
        {
        }
    }
}
