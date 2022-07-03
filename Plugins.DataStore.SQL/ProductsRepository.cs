using CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly MarketContext _db;
        public ProductsRepository(MarketContext db)
        {
            _db = db;
        }

        public void AddProduct(Product product)
        {
            _db.Product.Add(product);
            _db.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var product = GetProductById(productId);
            if (product == null)
            {
                return;
            }

            _db.Remove(product);
            _db.SaveChanges();
        }

        public IEnumerable<Product> GetProductByCategoryId(int categoryId)
        {
            return _db.Product.Where(p => p.CategoryId == categoryId).ToList();
        }

        public Product GetProductById(int productId)
        {
            return _db.Product.Find(productId);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _db.Product.ToList();
        }

        public void UpdateProduct(Product product)
        {
            var productToUpdate = GetProductById(product.ProductId);
            if (productToUpdate == null)
            {
                return;
            }

            productToUpdate.Copy(product);
            _db.SaveChanges();
        }
    }
}
