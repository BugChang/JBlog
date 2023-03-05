using AutoMapper;
using JBlog.Application.ViewModels;
using JBlog.Core.Entity;

namespace JBlog.Application.AutoMapper
{
    public class EntityToViewModelProfile : Profile
    {

        public EntityToViewModelProfile()
        {
            CreateMap<Category, CategoryViewModel>();
        }
    }
}
