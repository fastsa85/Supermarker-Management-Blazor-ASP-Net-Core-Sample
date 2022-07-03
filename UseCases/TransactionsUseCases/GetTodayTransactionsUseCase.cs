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
    public class GetTodayTransactionsUseCase : IGetTodayTransactionsUseCase
    {
        private readonly ITransacionsRepository _transactionsRepository;

        public GetTodayTransactionsUseCase(ITransacionsRepository transactionsRepository)
        {
            _transactionsRepository = transactionsRepository;
        }
        public IEnumerable<Transaction> Execute(string cashierName)
        {
            return _transactionsRepository.GetByDate(DateTime.Now, cashierName);
        }
    }
}
