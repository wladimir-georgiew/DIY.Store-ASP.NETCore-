using DIY.Castle.Data.Models;
using DIY.Castle.Web.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DIY.Castle.Web.Services.CategoriesService
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ApplicationDbContext dbContext;

        public CategoriesService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddCategory(Category category)
        {
            await this.dbContext.Categories.AddAsync(category);
            await this.dbContext.SaveChangesAsync();
        }

        public IQueryable<Category> GetAllCategories()
        {
            var categories = this.dbContext.Categories.Include(x => x.Products).AsQueryable();
            return categories;
        }

        public Category GetCategoryByName(string name)
        {
            var category = this.dbContext.Categories.Where(x => x.Name == name).FirstOrDefault();

            return category;
        }

        public Category GetCategoryById(int id)
        {
            var category = this.dbContext.Categories.Where(x => x.Id == id).FirstOrDefault();

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
