using DbCard.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DbCard.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Infrastructure.Dto.Category.Category>> GetAll();

        Task<IEnumerable<Infrastructure.Dto.Category.Subcategory>> GetSubcategories(long id);
    }
}