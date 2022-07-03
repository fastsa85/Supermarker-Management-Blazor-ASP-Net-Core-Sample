using CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
    public class TransactionsRepository : ITransacionsRepository
    {
        private readonly MarketContext _db;
        public TransactionsRepository(MarketContext db)
        {
            _db = db;
        }

        public IEnumerable<Transaction> GetAll(string cashierName)
        {
            if (string.IsNullOrWhiteSpace(cashierName))
            {
                return _db.Transaction.ToList();
            }

            return _db.Transaction.Where(transaction => 
            transaction.CashierName.Equals(cashierName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public IEnumerable<Transaction> GetByDate(DateTime date, string cashierName)
        {
            var transactionsByDate = _db.Transaction.Where(x => x.Timestamp.Date == date.Date).ToList();
            if (string.IsNullOrWhiteSpace(cashierName))
            {
                return transactionsByDate;
            }

            return transactionsByDate.Where(x => x.CashierName.Equals(cashierName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public IEnumerable<Transaction> GetByDateRange(DateTime startDate, DateTime endDate, string cashierName)
        {
            var transactionsByDate = _db.Transaction.Where(x => x.Timestamp.Date >= startDate.Date && x.Timestamp <= endDate.AddDays(1)).ToList();
            if (string.IsNullOrWhiteSpace(cashierName))
            {
                return transactionsByDate;
            }

            return transactionsByDate.Where(x => x.CashierName.Equals(cashierName, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void Save(int productId, string productName, decimal price, int beforeQuantity, int soldQuantity, string cashierName)
        {
            _db.Transaction.Add(new Transaction
            {
                ProductId = productId,
                ProductName = productName,
                Price = price,
                BeforeQuantity = beforeQuantity,
                SoldQuantity = soldQuantity,
                Timestamp = DateTime.Now,
                CashierName = cashierName
            });
            _db.SaveChanges();
        }
    }
}
