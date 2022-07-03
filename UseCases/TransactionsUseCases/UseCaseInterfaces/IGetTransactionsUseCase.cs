using CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.TransactionsUseCases.UseCaseInterfaces
{
    public interface IGetTransactionsUseCase
    {
        IEnumerable<Transaction> Execute(DateTime startDate, DateTime endDate, string cashierName);
    }
}
