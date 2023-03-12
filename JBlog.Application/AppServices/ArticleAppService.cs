using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using AutoMapper;
using AutoMapper.Execution;
using JBlog.Application.AppInterfaces;
using JBlog.Application.ViewModels;
using JBlog.Common.Extensions;
using JBlog.Common.Models;
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

        public Task<PageResult<ArticleViewModel>> GetListAsync(ArticleQuery query)
        {
            var result = new PageResult<ArticleViewModel>();
            Expression<Func<Article, bool>> predicate = a => true;
            var queryable = _articleRepository.GetQueryable();
            if (query.CategoryId != 0)
            {
                predicate = predicate.And(a => a.CategoryId == query.CategoryId);
            }

            if (!string.IsNullOrEmpty(query.Keywords))
            {
                predicate = predicate.And(a => a.Title.Contains(query.Keywords) || a.Content.Contains(query.Keywords));
            }

            if (query.TagIds.Any())
            {
                predicate = predicate.And(
                    a => a.ArticleTags.Any(at => query.TagIds.Contains(at.TagId)));
            }

            if (query.OnlyPublished)
            {
                predicate = predicate.And(a => a.IsPublished);
            }
            if (!query.IgnoreTop)
            {
                predicate = predicate.Or(a => a.IsTop);
                queryable = queryable.OrderByDescending(a => a.IsTop).ThenByDescending(a => a.Id);
            }
            else
            {
                queryable = queryable.OrderByDescending(a => a.Id);
            }

            queryable = queryable.Where(predicate);
            result.TotalCount = queryable.Count();
            queryable = queryable.Skip(query.Skip).Take(query.Take);
            result.Page = query.Page;
            result.PageSize = query.PageSize;
            result.Records = _mapper.ProjectTo<ArticleViewModel>(queryable).ToList();
            return Task.FromResult(result);
        }
    }
}
