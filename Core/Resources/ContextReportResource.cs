using System;

namespace Comtele.Sdk.Core.Resources
{
    public class ContextReportResource
    {
        public string Sender { get; set; }
        public string Content { get; set; }
        public DateTime? Received { get; set; }
        public string StatusMessage { get; set; }
        public string ContextRuleName { get; set; }
    }
}
