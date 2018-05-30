using System;
using System.Collections.Generic;
using System.Text;

namespace Comtele.Sdk.Core.Resources
{
    public class CreditHistoryResource
    {
        public int Amount { get; set; }
        public int Balance { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime HistoryDate { get; set; }
        public string AssociadedUsername { get; set; }
    }
}
