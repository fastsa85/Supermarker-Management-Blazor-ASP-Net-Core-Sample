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
    public class ViewProductsUseCases : IViewProductsUseCase
    {
        private readonly IProductsRepository _productsRepository;
        public ViewProductsUseCases(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public IEnumerable<Product> Execute()
        {
            return _productsRepository.GetProducts();
        }
    }
}
