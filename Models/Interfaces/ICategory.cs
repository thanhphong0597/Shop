using DoAn.Entities;
using DoAn.Models.ViewModels;

namespace DoAn.Models.Interfaces
{
    public interface ICategory
    {
        Task<IEnumerable<CategoryItem>> GetCategories();
        Task<CategoryItem> GetCategory(int id);
        Task<Category> AddCategory(Category item);
        Task<Category> UpdateCategory(Category cat);
        Task DeleteCategory(int id);

    }
}
