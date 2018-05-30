using System;
using System.Collections.Generic;
using System.Text;

namespace Comtele.Sdk.Core.Resources
{
    public class DetailedReportResource
    {
        public string Receiver { get; set; }
        public string Content { get; set; }
        public string Status { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public DateTime RequestDate { get; set; }
        public string SystemMessage { get; set; }
        public string DlrStatus { get; set; }
        public string Sender { get; set; }
    }
}
