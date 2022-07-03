using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.Models
{
    public class Category
    {       
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public IEnumerable<Product> Products { get; set; }

        public Category Clone()
        {
            return new Category
            {
                CategoryId = CategoryId,
                Name = Name,
                Description = Description
            };
        }

        public void Copy(Category category)
        {
            CategoryId = category.CategoryId;   
            Name = category.Name;   
            Description = category.Description; 
        }
    }
}
