using CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.ProductsUseCases.UseCaseInterfaces;

namespace UseCases.ProductsUseCases
{
    public class EditProductUseCase : IEditProductUseCase
    {
        private readonly IProductsRepository _productRepository;

        public EditProductUseCase(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Execute(Product product)
        {
            _productRepository.UpdateProduct(product);
        }
    }
}
