using CoreBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces
{
    public interface ITransacionsRepository
    {
        public void Save(int productId, string productName, decimal price, int beforeQuantity, int soldQuantity, string cashierName);
        public IEnumerable<Transaction> GetByDate(DateTime date, string cashierName);
        public IEnumerable<Transaction> GetByDateRange(DateTime startDate, DateTime endDate, string cashierName);
        public IEnumerable<Transaction> GetAll(string cashierName);
    }
}
