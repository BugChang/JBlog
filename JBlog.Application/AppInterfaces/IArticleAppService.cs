using JBlog.Application.ViewModels;
using JBlog.Common.Models;

namespace JBlog.Application.AppInterfaces
{
    public interface IArticleAppService
    {
        public Task AddAsync(ArticleViewModel viewModel);

        public Task UpdateAsync(ArticleViewModel viewModel);

        public Task<ArticleViewModel> GetByIdAsync(int id);

        public Task DeleteAsync(int id);

        public Task<IList<ArticleViewModel>> GetListAsync();

        public Task<PageResult<ArticleViewModel>> GetListAsync(ArticleQuery query);
    }
}
