using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.ProductsUseCases.UseCaseInterfaces;
using UseCases.TransactionsUseCases.UseCaseInterfaces;

namespace UseCases.ProductsUseCases
{
    public class SellProductUseCase : ISellProductUseCase
    {
        private readonly IProductsRepository _productsRepository;
        private readonly IRecordTransactionUseCase _recordTransactionUseCase;
        public SellProductUseCase(IProductsRepository productsRepository,
            IRecordTransactionUseCase recordTransactionUseCase)
        {
            _productsRepository = productsRepository;
            _recordTransactionUseCase = recordTransactionUseCase;
        }
        public void Execute(int productId, int quantityToSell, string cashierName)
        {
            var product = _productsRepository.GetProductById(productId);
            if (product == null) return;

            _recordTransactionUseCase.Execute(productId, quantityToSell, cashierName);
            product.Quantity -= quantityToSell;
            _productsRepository.UpdateProduct(product);            
        }
    }
}
