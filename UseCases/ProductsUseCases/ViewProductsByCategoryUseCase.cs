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
    public class ViewProductsByCategoryUseCase : IViewProductsByCategoryUseCase
    {
        private readonly IProductsRepository _productsRepository;
        public ViewProductsByCategoryUseCase(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public IEnumerable<Product> Execute(int categoryId)
        {
            return _productsRepository.GetProductByCategoryId(categoryId);
        }
    }
}
