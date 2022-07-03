using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.ProductsUseCases.UseCaseInterfaces;
using UseCases.TransactionsUseCases.UseCaseInterfaces;

namespace UseCases.TransactionsUseCases
{
    public class RecordTransactionUseCase : IRecordTransactionUseCase
    {
        ITransacionsRepository _transactionsRepository;
        IGetProductByIdUseCase _getProductByIdUseCase;

        public RecordTransactionUseCase(ITransacionsRepository transactionsRepository,
            IGetProductByIdUseCase getProductByIdUseCase)
        {
            _transactionsRepository = transactionsRepository;
            _getProductByIdUseCase = getProductByIdUseCase;
        }

        public void Execute(int productId, int quantity, string cashierName)
        {
            var product = _getProductByIdUseCase.Execute(productId);
            _transactionsRepository.Save(productId, product.Name, product.Price.Value, product.Quantity.Value, quantity, cashierName);
        }
    }
}
