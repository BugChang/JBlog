using JBlog.Application.ViewModels;

namespace JBlog.Application.AppInterfaces
{
    public interface IArticleAppService
    {
        public Task AddAsync(ArticleViewModel viewModel);

        public Task UpdateAsync(ArticleViewModel viewModel);

        public Task<ArticleViewModel> GetByIdAsync(int id);

        public Task DeleteAsync(int id);

        public Task<IList<ArticleViewModel>> GetListAsync();
    }
}
