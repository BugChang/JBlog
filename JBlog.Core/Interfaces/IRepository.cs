using JBlog.Common.Models;
using JBlog.Core.Entity;

namespace JBlog.Core.Interfaces
{
    public interface IRepository<TModel> where TModel : EntityBase
    {
        public Task<TModel> GetAsync(int id);

        public Task<IList<TModel>> GetListAsync();

        public Task AddAsync(TModel model);

        public Task DeleteAsync(int id);

        public Task UpdateAsync(TModel model);

        public IQueryable<TModel> GetQueryable();
    }
}
