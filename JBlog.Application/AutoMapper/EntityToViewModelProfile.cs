using AutoMapper;
using JBlog.Application.ViewModels;
using JBlog.Core.Entity;

namespace JBlog.Application.AutoMapper
{
    public class EntityToViewModelProfile : Profile
    {
        private const string DateFormatString = "yyyy-MM-dd HH:mm";
        public EntityToViewModelProfile()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Article, ArticleViewModel>()
                .ForMember(d => d.CategoryName, o => o.MapFrom(s => s.Category.Name))
                .ForMember(d => d.PublishOn, o => o.MapFrom(s => s.PublishOn.HasValue ? s.PublishOn.Value.ToString(DateFormatString) : ""))
                .ForMember(d => d.CreateOn, o => o.MapFrom(s => s.CreateOn.ToString(DateFormatString)))
                .ForMember(d => d.UpdateOn, o => o.MapFrom(s => s.UpdateOn.HasValue ? s.UpdateOn.Value.ToString(DateFormatString) : ""));
        }
    }
}
