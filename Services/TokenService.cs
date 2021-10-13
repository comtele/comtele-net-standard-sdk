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

        public ServiceResult<object> SendToken(string phoneNumber, string prefix, bool enforceSecureValidation)
        {
            var restClient = new RestClient(ENDPOINT_ADDRESS);
            var restRequest = new RestRequest("tokenmanager", Method.POST);

            restRequest.AddHeader("auth-key", ApiKey);
            restRequest.AddJsonBody(new { phoneNumber, prefix });

            var restResponse = restClient.Execute<ServiceResult<object>>(restRequest);

            return restResponse.Data;
        }

        public ServiceResult<object> SendToken(string phoneNumber, bool enforceSecureValidation)
        {
            return SendToken(phoneNumber, string.Empty, enforceSecureValidation);
        }

        public async Task<ServiceResult<object>> SendTokenAsync(string phoneNumber, string prefix, bool enforceSecureValidation)
        {
            return await Task.Run(() => SendToken(phoneNumber, prefix, enforceSecureValidation));
        }

        public async Task<ServiceResult<object>> SendTokenAsync(string phoneNumber, bool enforceSecureValidation)
        {
            return await Task.Run(() => SendToken(phoneNumber, enforceSecureValidation));
        }

        public ServiceResult<object> ValidateToken(string tokenCode, string phoneNumber)
        {
            var restClient = new RestClient(ENDPOINT_ADDRESS);
            var restRequest = new RestRequest("tokenmanager", Method.PUT);

            restRequest.AddHeader("auth-key", ApiKey);
            restRequest.AddJsonBody(new { tokenCode, phoneNumber });

            var restResponse = restClient.Execute<ServiceResult<object>>(restRequest);

            return restResponse.Data;
        }

        public async Task<ServiceResult<object>> ValidateTokenAsync(string tokenCode, string phoneNumber)
        {
            return await Task.Run(() => ValidateToken(tokenCode, phoneNumber));
        }
    }
}
