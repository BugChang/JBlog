using AutoMapper;
using JBlog.Application.AppInterfaces;
using JBlog.Application.ViewModels;
using JBlog.Core.Entity;
using JBlog.Core.Interfaces;

namespace JBlog.Application.AppServices
{
    public class ArticleAppService : IArticleAppService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IArticleRepository _articleRepository;

        public ArticleAppService(IUnitOfWork unitOfWork, IMapper mapper, IArticleRepository articleRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _articleRepository = articleRepository;
        }

        public async Task AddAsync(ArticleViewModel viewModel)
        {
            var entity = _mapper.Map<Article>(viewModel);
            await _articleRepository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(ArticleViewModel viewModel)
        {
            var entity = await _articleRepository.GetAsync(viewModel.Id);
            _mapper.Map(viewModel, entity);
            await _unitOfWork.CommitAsync();
        }

        public async Task<ArticleViewModel> GetByIdAsync(int id)
        {
            var entity = await _articleRepository.GetAsync(id);
            return _mapper.Map<ArticleViewModel>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            await _articleRepository.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
        }

        public Task<IList<ArticleViewModel>> GetListAsync()
        {
            return Task.FromResult<IList<ArticleViewModel>>(_mapper.ProjectTo<ArticleViewModel>(_articleRepository.GetQueryable()).ToList());
        }
    }
}
