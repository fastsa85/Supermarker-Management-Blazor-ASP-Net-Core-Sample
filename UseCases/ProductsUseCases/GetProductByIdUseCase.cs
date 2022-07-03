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
    public class GetProductByIdUseCase : IGetProductByIdUseCase
    {
        private readonly IProductsRepository _productsRepository;

        public GetProductByIdUseCase(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public Product Execute(int productId)
        {
            return _productsRepository.GetProductById(productId);
        }
    }
}
