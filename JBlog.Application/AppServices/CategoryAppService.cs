using AutoMapper;
using JBlog.Application.AppInterfaces;
using JBlog.Application.ViewModels;
using JBlog.Core.Entity;
using JBlog.Core.Interfaces;

namespace JBlog.Application.AppServices
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CategoryAppService(ICategoryRepository categoryRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public Task<IList<CategoryViewModel>> GetListAsync()
        {
            return Task.FromResult<IList<CategoryViewModel>>(_mapper.ProjectTo<CategoryViewModel>(_categoryRepository.GetQueryable()).ToList());
        }

        public async Task<CategoryViewModel> GetByIdAsync(int id)
        {
            var entity = await _categoryRepository.GetAsync(id);
            return _mapper.Map<CategoryViewModel>(entity);
        }

        public async Task AddAsync(CategoryViewModel viewModel)
        {
            var entity = _mapper.Map<Category>(viewModel);
            await _categoryRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(CategoryViewModel viewModel)
        {
            var entity = _mapper.Map<Category>(viewModel);
            await _categoryRepository.UpdateAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
           await _categoryRepository.DeleteAsync(id);
           await _unitOfWork.CommitAsync();
        }
    }
}
