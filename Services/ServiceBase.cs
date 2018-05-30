using System;
using System.Collections.Generic;
using System.Text;

namespace Comtele.Sdk.Services
{
    public abstract class ServiceBase
    {
        protected const string ENDPOINT_ADDRESS = "https://sms.comtele.com.br/api/v2";
        protected readonly string ApiKey;

        public ServiceBase(string apiKey) => ApiKey = apiKey;
    }
}
