using Library.Models;
using Library.Repositories.UnitOfWorkPattern;

namespace Library.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddCategory(Category category)
        {
            await _unitOfWork.GenericRepository<Category>().AddAsync(category);
            _unitOfWork.Save();
        }

        public async Task DeleteCategory(Guid id)
        {
            var category = await _unitOfWork.GenericRepository<Category>().GetByIdAsync(filter: x => x.Id == id);
            _unitOfWork.GenericRepository<Category>().Delete(category);
            _unitOfWork.Save();
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _unitOfWork.GenericRepository<Category>().GetAll();
        }

        public async Task<Category> GetCategory(Guid id)
        {
            return await _unitOfWork.GenericRepository<Category>().GetByIdAsync(filter: x => x.Id == id);
        }

        public async Task UpdateCategory(Category category)
        {
            var CategoryFromDb = await _unitOfWork.GenericRepository<Category>().GetByIdAsync(filter: x => x.Id == category.Id);
            if (CategoryFromDb != null)
            {
                CategoryFromDb.Name = category.Name;
                _unitOfWork.GenericRepository<Category>().Update(CategoryFromDb);
                _unitOfWork.Save();
            }

        }
    }
}
