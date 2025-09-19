using Library.Models;

namespace Library.Services
{
    public interface ICategoryService
    {
        Task AddCategory(Category category);
        Task UpdateCategory(Category category);
        Task DeleteCategory(Guid id);
        Task<Category> GetCategory(Guid id);
        Task<IEnumerable<Category>> GetAllCategories();
    }
}
