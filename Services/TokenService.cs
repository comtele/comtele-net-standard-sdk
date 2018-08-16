using Comtele.Sdk.Core.Resources;
using Comtele.Sdk.Core.Services;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comtele.Sdk.Services
{
    public class TokenService : ServiceBase, ITokenService
    {
        public TokenService(string apiKey) : base(apiKey) { }

        public ServiceResult<object> SendToken(string phoneNumber, string prefix)
        {
            var restClient = new RestClient(ENDPOINT_ADDRESS);
            var restRequest = new RestRequest("tokenmanager", Method.POST);

            restRequest.AddHeader("auth-key", ApiKey);
            restRequest.AddJsonBody(new { phoneNumber, prefix });

            var restResponse = restClient.Execute<ServiceResult<object>>(restRequest);

            return restResponse.Data;
        }

        public ServiceResult<object> SendToken(string phoneNumber)
        {
            return SendToken(phoneNumber, string.Empty);
        }

        public async Task<ServiceResult<object>> SendTokenAsync(string phoneNumber, string prefix)
        {
            return await Task.Run(() => SendToken(phoneNumber, prefix));
        }

        public async Task<ServiceResult<object>> SendTokenAsync(string phoneNumber)
        {
            return await Task.Run(() => SendToken(phoneNumber));
        }

        public ServiceResult<object> ValidateToken(string tokenCode)
        {
            var restClient = new RestClient(ENDPOINT_ADDRESS);
            var restRequest = new RestRequest("tokenmanager", Method.PUT);

            restRequest.AddHeader("auth-key", ApiKey);
            restRequest.AddJsonBody(new { tokenCode });

            var restResponse = restClient.Execute<ServiceResult<object>>(restRequest);

            return restResponse.Data;
        }

        public async Task<ServiceResult<object>> ValidateTokenAsync(string tokenCode)
        {
            return await Task.Run(() => ValidateToken(tokenCode));
        }
    }
}
