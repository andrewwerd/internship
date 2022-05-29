using AutoMapper;
using WebApi.Infrastructure.DTO.Category;

namespace WebApi.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Domain.Category> _repositoryCategory;
        private readonly IRepository<Domain.Subcategory> _repositorySubcategory;
        private readonly IMapper _mapper;
        public CategoryService(IRepository<Domain.Category> repository, IRepository<Domain.Subcategory> subcategory, IMapper mapper)
        {
            _repositoryCategory = repository;
            _repositorySubcategory = subcategory;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            var categories = await _repositoryCategory.GetAll();
            return categories.Select(x => _mapper.Map<Category>(x));
        }

        public async Task<IEnumerable<Subcategory>> GetSubcategories(long id)
        {
            var subcategories = await _repositorySubcategory.GetByPredicate(x => x.CategoryId == id);
            return subcategories.Select(x => _mapper.Map<Subcategory>(x));
        }
    }
}
