using System;
using System.Collections.Generic;
using System.Text;

namespace Comtele.Sdk.Core.Resources
{
    public class ServiceResult<T> where T : class
    {
        public T Object { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
