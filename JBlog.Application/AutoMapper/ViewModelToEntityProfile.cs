using AutoMapper;
using JBlog.Application.ViewModels;
using JBlog.Core.Entity;

namespace JBlog.Application.AutoMapper
{
    public class ViewModelToEntityProfile : Profile
    {
        public ViewModelToEntityProfile()
        {
            CreateMap<CategoryViewModel, Category>();
            CreateMap<ArticleViewModel, Article>()
                .ForMember(d => d.CreateOn, o => o.Ignore())
                .ForMember(d => d.UpdateOn, o => o.Ignore())
                .ForMember(d => d.PublishOn, o => o.Ignore())
                .ForMember(d => d.IsDeleted, o => o.Ignore());
        }
    }
}
