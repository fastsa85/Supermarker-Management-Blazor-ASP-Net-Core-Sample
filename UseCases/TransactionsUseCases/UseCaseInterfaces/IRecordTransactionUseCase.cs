using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.TransactionsUseCases.UseCaseInterfaces
{
    public interface IRecordTransactionUseCase
    {
        public void Execute(int productId, int quantity, string cashierName);
    }
}
