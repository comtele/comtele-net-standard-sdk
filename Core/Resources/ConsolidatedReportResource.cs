using System;
using System.Collections.Generic;
using System.Text;

namespace Comtele.Sdk.Core.Resources
{
    public class ConsolidatedReportResource
    {
        public string Date { get; set; }
        public int Accepted { get; set; }
        public int Delivered { get; set; }
        public int Rejected { get; set; }
        public int Expired { get; set; }
        public int Undelivered { get; set; }
        public int Reply { get; set; }
        public int Total { get; set; }
    }
}
