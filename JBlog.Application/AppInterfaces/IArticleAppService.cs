using JBlog.Application.ViewModels;

namespace JBlog.Application.AppInterfaces
{
    public interface IArticleAppService
    {
        public Task AddAsync(ArticleWriteViewModel viewModel);
    }
}
