using JBlog.Core.Entity;
using JBlog.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JBlog.Data.Repository
{
    public class RepositoryBase<TModel> : IRepository<TModel> where TModel : EntityBase
    {
        public DbSet<TModel> DbSet { get; set; }
        public RepositoryBase(JBlogDbContext dbContext)
        {
            DbSet = dbContext.Set<TModel>();
        }

        public async Task<TModel> GetAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IList<TModel>> GetListAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task AddAsync(TModel model)
        {
            await DbSet.AddAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            entity.IsDeleted = true;
        }

        public Task UpdateAsync(TModel model)
        {
            DbSet.Update(model);
            return Task.CompletedTask;
        }

        public IQueryable GetQueryable()
        {
            return DbSet.AsQueryable();
        }
    }
}
