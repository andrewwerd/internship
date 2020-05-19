using AutoMapper;
using DbCard.Domain;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbCard.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _repositoryCategory;
        private readonly IRepository<Subcategory> _repositorySubcategory;
        private readonly IMapper _mapper;
        public CategoryService(IRepository<Category> repository, IRepository<Subcategory> subcategory, IMapper mapper)
        {
            _repositoryCategory = repository;
            _repositorySubcategory = subcategory;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Infrastructure.Dto.Category.Category>> GetAll()
        {
            var categories = await _repositoryCategory.GetAll();
            return categories.Select(x => _mapper.Map<Infrastructure.Dto.Category.Category>(x));
        }

        public async Task<IEnumerable<Infrastructure.Dto.Category.Subcategory>> GetSubcategories(long id)
        {
            var subcategories = await _repositorySubcategory.GetByPredicate(x => x.CategoryId == id);
            return subcategories.Select(x => _mapper.Map<Infrastructure.Dto.Category.Subcategory>(x));
        }
    }
}
