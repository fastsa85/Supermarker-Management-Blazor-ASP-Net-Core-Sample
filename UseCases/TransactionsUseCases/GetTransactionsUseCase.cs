using CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.TransactionsUseCases.UseCaseInterfaces;

namespace UseCases.TransactionsUseCases
{
    public class GetTransactionsUseCase : IGetTransactionsUseCase
    {
        private readonly ITransacionsRepository _transactionsRepository;

        public GetTransactionsUseCase(ITransacionsRepository transactionsRepository)
        {
            _transactionsRepository = transactionsRepository;
        }
        public IEnumerable<Transaction> Execute(DateTime startDate, DateTime endDate, string cashierName)
        {
            return _transactionsRepository.GetByDateRange(startDate, endDate, cashierName);
        }
    }
}
