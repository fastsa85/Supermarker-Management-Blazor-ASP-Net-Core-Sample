using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public int? CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int? Quantity { get; set; }
        [Required]
        public decimal? Price { get; set; }

        public Category Category { get; set; }

        public Product Clone()
        {
            return new Product
            {
                ProductId = ProductId,
                CategoryId = CategoryId,
                Name = Name,                
                Quantity = Quantity,
                Price = Price                
            };
        }

        public void Copy(Product product)
        {
            CategoryId = product.CategoryId;
            Name = product.Name;    
            Quantity = product.Quantity;
            Price = product.Price;
        }
    }
}
