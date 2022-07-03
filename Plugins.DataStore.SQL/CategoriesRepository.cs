using CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly MarketContext _db;
        public CategoriesRepository(MarketContext db)
        {
            _db = db;
        }

        public void AddCategory(Category category)
        {
            _db.Category.Add(category);
            _db.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = GetCategoryById(categoryId);
            if (category == null)
            {
                return;
            }

            _db.Category.Remove(category);
            _db.SaveChanges(true);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _db.Category.ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            return _db.Category.Find(categoryId);
        }

        public void UpdateCategory(Category category)
        {
            var categoryToUpdate = GetCategoryById(category.CategoryId);
            if (categoryToUpdate == null)
            {
                return;
            }

            categoryToUpdate.Copy(category);
            _db.SaveChanges();
        }
    }
}
