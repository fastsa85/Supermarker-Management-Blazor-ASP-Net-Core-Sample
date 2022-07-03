using CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
    public class TransactionsInMemoryRepository : ITransacionsRepository
    {
        private List<Transaction> transactions;

        public TransactionsInMemoryRepository()
        {
            transactions = new List<Transaction>();
        }

        public IEnumerable<Transaction> GetAll(string cashierName)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
            {
                return transactions;
            }
            else
            {
                return transactions.Where(x => x.CashierName == cashierName);   
            }            
        }

        public IEnumerable<Transaction> GetByDate(DateTime date, string cashierName)
        {
            var transactionsByDate = transactions.Where(x => x.Timestamp.Date == date.Date);
            if (string.IsNullOrWhiteSpace(cashierName))
            {
                return transactions;
            }
            else
            {
                return transactionsByDate.Where(x => x.CashierName.Equals(cashierName, StringComparison.OrdinalIgnoreCase));
            }
        }

        public IEnumerable<Transaction> GetByDateRange(DateTime startDate, DateTime endDate, string cashierName)
        {
            var transactionsByDate = transactions.Where(x => x.Timestamp.Date >= startDate.Date && x.Timestamp <= endDate.AddDays(1));
            if (string.IsNullOrWhiteSpace(cashierName))
            {
                return transactionsByDate;
            }
            else
            {
                return transactionsByDate.Where(x => x.CashierName.Equals(cashierName, StringComparison.OrdinalIgnoreCase));
            }
        }

        public void Save(int productId, string productName, decimal price, int beforeQuantity, int soldQuantity, string cashierName)
        {
            var transactionId = 0;
            if (transactions != null && transactions.Count > 0)
            {
                transactionId = transactions.Max(x => x.TransactionId) + 1;
            }
            else
            {
                transactionId = 1;
            }

            transactions.Add(new Transaction
            {
                ProductId = productId, 
                ProductName = productName,  
                Price = price,
                BeforeQuantity = beforeQuantity,
                SoldQuantity = soldQuantity,
                Timestamp = DateTime.Now,
                CashierName = cashierName
            });
        }
    }
}
