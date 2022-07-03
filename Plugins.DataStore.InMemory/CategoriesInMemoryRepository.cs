using CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class CategoriesInMemoryRepository : ICategoriesRepository
    {
        private readonly List<Category> _categories;

        public CategoriesInMemoryRepository()
        {
            _categories = new List<Category>()
            {
                new Category() { CategoryId = 1, Name = "Beverage", Description = "Beverage"},
                new Category() { CategoryId = 2, Name = "Bakery", Description = "Bakery"},
                new Category() { CategoryId = 3, Name = "Meat", Description = "Meat"}
            };
        }

        public void AddCategory(Category category)
        {
            if (_categories.Any(x => x.Name.Equals(category.Name, StringComparison.OrdinalIgnoreCase))) return;
            category.CategoryId = (_categories != null && _categories.Count > 0) ? _categories.Max(x => x.CategoryId) + 1 : 1;
            _categories.Add(category);
        }

        public void DeleteCategory(int categoryId)
        {
            _categories.Remove(GetCategoryById(categoryId));
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categories;
        }

        public Category GetCategoryById(int categoryId)
        {
            return _categories?.FirstOrDefault(x => x.CategoryId == categoryId);
        }

        public void UpdateCategory(Category category)
        {
            var categoryToUpdate = GetCategoryById(category.CategoryId);
            if (categoryToUpdate != null) 
            {
                categoryToUpdate.Copy(category);                 
            }
        }
    }
}
