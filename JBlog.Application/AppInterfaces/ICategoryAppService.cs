using JBlog.Application.ViewModels;

namespace JBlog.Application.AppInterfaces
{
    public interface ICategoryAppService
    {
        Task<IList<CategoryViewModel>> GetListAsync();

        Task AddAsync(CategoryViewModel viewModel);
    }
}
