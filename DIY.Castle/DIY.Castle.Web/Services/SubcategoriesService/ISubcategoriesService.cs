using DIY.Castle.Data.Models;
using System.Linq;
using System.Threading.Tasks;

namespace DIY.Castle.Web.Services.SubcategoriesService
{
    public interface ISubcategoriesService
    {
        public Task AddCategory(Subcategory category);

        public IQueryable<Subcategory> GetAllCategories();

        public Subcategory GetCategoryById(int id);

        public Subcategory GetCategoryByName(string name);

        public Task UpdateCategoryById(int id, string updatedName);
    }
}
