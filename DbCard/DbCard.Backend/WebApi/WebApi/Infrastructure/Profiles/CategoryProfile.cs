using AutoMapper;
using WebApi.Infrastructure.DTO.Category;

namespace WebApi.Infrastructure.Profiles
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile()
        {
            CreateMap<Domain.Category, Category>();
            CreateMap<Domain.Subcategory, Subcategory>();
        }
    }
}
