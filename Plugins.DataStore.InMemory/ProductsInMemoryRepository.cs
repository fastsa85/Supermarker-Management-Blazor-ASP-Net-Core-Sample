using CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class ProductsInMemoryRepository : IProductsRepository
    {
        private readonly List<Product> _products;

        public ProductsInMemoryRepository()
        {
            _products = new List<Product>()
            {
                new Product() { ProductId = 1, CategoryId = 1, Name = "Iced Tea", Quantity = 100, Price = 1.99m},
                new Product() { ProductId = 2, CategoryId = 1, Name = "Ginger Ale", Quantity = 99, Price = 0.99m},
                new Product() { ProductId = 3, CategoryId = 2, Name = "Whole Wheat Bread", Quantity = 199, Price = 1.19m},
                new Product() { ProductId = 4, CategoryId = 2, Name = "White Bread", Quantity = 88, Price = 1.50m},
                new Product() { ProductId = 5, CategoryId = 2, Name = "Donut", Quantity = 51, Price = 0.55m},
                new Product() { ProductId = 6, CategoryId = 3, Name = "Pork", Quantity = 24, Price = 5.01m},
                new Product() { ProductId = 7, CategoryId = 3, Name = "Beef", Quantity = 19, Price = 4.69m},
                new Product() { ProductId = 8, CategoryId = 3, Name = "Chicken", Quantity = 12, Price = 3.99m},

            };
        }

        public void AddProduct(Product product)
        {
            if (_products.Any(x => x.Name.Equals(product.Name, StringComparison.OrdinalIgnoreCase))) return;
            product.ProductId = (_products != null && _products.Count > 0) ? _products.Max(x => x.ProductId) + 1 : 1;
            _products.Add(product);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }

        public void UpdateProduct(Product product)
        {
            var productToUpdate = GetProductById(product.ProductId);
            if (productToUpdate != null)
            {
                productToUpdate.Copy(product);
            }
        }

        public Product GetProductById(int productId)
        {
            return _products?.FirstOrDefault(x => x.ProductId == productId);
        }

        public void DeleteProduct(int productId)
        {
            var productToDelete = GetProductById(productId);

            if (productToDelete != null)
            {
                _products?.Remove(productToDelete);
            }
        }

        public IEnumerable<Product> GetProductByCategoryId(int categoryId)
        {
            return _products?.Where(x => x.CategoryId == categoryId);
        }
    }
}
