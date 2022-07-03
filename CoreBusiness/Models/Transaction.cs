using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusiness.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime Timestamp { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int BeforeQuantity { get; set; }
        public int SoldQuantity { get; set; }
        public decimal Price { get; set; }
        public string CashierName { get; set; }
    }
}
