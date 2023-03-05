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
        }
    }
}
