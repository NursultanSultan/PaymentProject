using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPay.Entity.Concrete
{
    public class CustomerAccount
    {
        public int AccountID { get; set; }
        public string AccountNumber { get; set; }
        public string Currency { get; set; }
        public decimal Balance { get; set; }
        public string BankBranch { get; set; }
    }
}
