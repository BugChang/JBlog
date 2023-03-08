using JBlog.Core.Entity;
using JBlog.Core.Interfaces;

namespace JBlog.Data.Repository
{
    public class ArticleRepository:RepositoryBase<Article>,IArticleRepository
    {
        public ArticleRepository(JBlogDbContext dbContext) : base(dbContext)
        {
        }
    }
}
