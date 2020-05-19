using AutoMapper;

namespace DbCard.Infrastructure.Profiles
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile()
        {
            CreateMap<Domain.Category, Dto.Category.Category>();
            CreateMap<Domain.Subcategory, Dto.Category.Subcategory>();
        }
    }
}
