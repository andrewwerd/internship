using WebApi.Infrastructure.DTO.Category;

namespace WebApi.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetAll();

        Task<IEnumerable<Subcategory>> GetSubcategories(long id);
    }
}