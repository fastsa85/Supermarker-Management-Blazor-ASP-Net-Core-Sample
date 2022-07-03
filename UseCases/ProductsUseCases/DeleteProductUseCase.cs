using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.ProductsUseCases.UseCaseInterfaces;

namespace UseCases.ProductsUseCases
{
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IProductsRepository _productsRepository;
        public DeleteProductUseCase(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public void Execute(int productId)
        {
            _productsRepository.DeleteProduct(productId);
        }
    }
}
