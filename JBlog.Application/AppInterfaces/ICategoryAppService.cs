using JBlog.Application.ViewModels;

namespace JBlog.Application.AppInterfaces
{
    public interface ICategoryAppService
    {
        Task<IList<CategoryViewModel>> GetListAsync();

        Task<CategoryViewModel> GetByIdAsync(int id);

        Task AddAsync(CategoryViewModel viewModel);

        Task UpdateAsync(CategoryViewModel viewModel);

        Task DeleteAsync(int id);
    }
}
