using DIY.Castle.Data.Models;
using DIY.Castle.Web.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DIY.Castle.Web.Services.SubcategoriesService
{
    public class SubcategoriesService : ISubcategoriesService
    {
        private readonly ApplicationDbContext dbContext;

        public SubcategoriesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddCategory(Subcategory category)
        {
            await this.dbContext.Subcategories.AddAsync(category);
            await this.dbContext.SaveChangesAsync();
        }

        public IQueryable<Subcategory> GetAllCategories()
        {
            var categories = this.dbContext.Subcategories.AsQueryable();
            return categories;
        }

        public Subcategory GetCategoryByName(string name)
        {
            var category = this.dbContext.Subcategories.Where(x => x.Name == name).FirstOrDefault();

            return category;
        }

        public Subcategory GetCategoryById(int id)
        {
            var category = this.dbContext.Subcategories.Where(x => x.Id == id).FirstOrDefault();

            return category;
        }

        public async Task UpdateCategoryById(int id, string updatedName)
        {
            var category = this.GetCategoryById(id);

            category.Name = updatedName;

            await this.dbContext.SaveChangesAsync();
        }
    }
}
