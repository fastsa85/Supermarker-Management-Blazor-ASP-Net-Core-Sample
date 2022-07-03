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
    public class AddProductUseCase : IAddProductUseCase
    {
        private readonly IProductsRepository _productsRepository;

        public AddProductUseCase(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public void Execute(Product product)
        {
            _productsRepository.AddProduct(product);
        }
    }
}
