using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyPay.Entity.Concrete
{
    public class CustomerAccount
    {
        public int ID { get; set; }
        public string AccountNumber { get; set; }
        public string Currency { get; set; }
        public decimal Balance { get; set; }
        public string BankBranch { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
