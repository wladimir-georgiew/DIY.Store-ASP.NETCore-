using DIY.Castle.Data.Models;
using System.Linq;
using System.Threading.Tasks;

namespace DIY.Castle.Web.Services.CategoriesService
{
    public interface ICategoriesService
    {
        Task AddCategory(Category category);

        IQueryable<Category> GetAllCategories();

        Category GetCategoryByName(string name);

        Category GetCategoryById(int id);

        Task UpdateCategoryById(int id, string updatedName);
    }
}
