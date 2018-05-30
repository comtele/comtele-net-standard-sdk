using System;
using System.Collections.Generic;
using System.Text;

namespace Comtele.Sdk.Core.Resources
{
    public class AccountDetailResource
    {
        public int Balance { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool UseShortCode { get; set; }
        public DateTime? Connection { get; set; }
        public DateTime? LastBalanceHistory { get; set; }
    }
}
