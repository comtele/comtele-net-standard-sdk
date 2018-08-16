using System;
using System.Collections.Generic;
using System.Text;

namespace Comtele.Sdk.Core.Resources
{
    public class ContactGroupResource
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int TotalContacts { get; set; }
        public DateTime? LastUsed { get; set; }
    }
}
