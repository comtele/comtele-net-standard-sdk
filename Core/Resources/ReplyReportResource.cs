using System;

namespace Comtele.Sdk.Core.Resources
{
    public class ReplyReportResource
    {
        public string Sender { get; set; }
        public string SenderName { get; set; }
        public string SentContent { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string ReceivedContent { get; set; }
    }
}
