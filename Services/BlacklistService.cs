using Comtele.Sdk.Core.Resources;
using Comtele.Sdk.Core.Services;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comtele.Sdk.Services
{
    public class BlacklistService : ServiceBase, IBlacklistService
    {
        public BlacklistService(string apiKey)
            : base(apiKey)
        { }

        public ServiceResult<List<BlacklistResource>> GetBlacklist()
        {
            var client = new RestClient(ENDPOINT_ADDRESS);
            var request = new RestRequest("blacklist", Method.GET);

            request.AddHeader("auth-key", ApiKey);

            var response = client.Execute<ServiceResult<List<BlacklistResource>>>(request);
            return response.Data;
        }

        public async Task<ServiceResult<List<BlacklistResource>>> GetBlacklistAsync()
        {
            return await Task.Run(() => GetBlacklist());
        }

        public BlacklistResource GetByPhoneNumber(string phoneNumber)
        {
            var client = new RestClient(ENDPOINT_ADDRESS);
            var request = new RestRequest("blacklist", Method.GET);

            request.AddHeader("auth-key", ApiKey);
            request.AddQueryParameter("id", phoneNumber);

            var response = client.Execute<ServiceResult<List<BlacklistResource>>>(request);
            return response.Data?.Object?.FirstOrDefault();
        }

        public async Task<BlacklistResource> GetByPhoneNumberAsync(string phoneNumber)
        {
            return await Task.Run(() => GetByPhoneNumber(phoneNumber));
        }

        public ServiceResult<object> Insert(string phoneNumber)
        {
            var client = new RestClient(ENDPOINT_ADDRESS);
            var request = new RestRequest("blacklist", Method.POST);

            request.AddHeader("auth-key", ApiKey);
            request.AddJsonBody(new { phoneNumber });            

            var response = client.Execute<ServiceResult<object>>(request);
            return response.Data;
        }

        public async Task<ServiceResult<object>> InsertAsync(string phoneNumber)
        {
            return await Task.Run(() => Insert(phoneNumber));
        }

        public ServiceResult<object> Remove(string phoneNumber)
        {
            var client = new RestClient(ENDPOINT_ADDRESS);
            var request = new RestRequest("blacklist", Method.DELETE);

            request.AddHeader("auth-key", ApiKey);
            request.AddQueryParameter("id", phoneNumber);

            var response = client.Execute<ServiceResult<object>>(request);
            return response.Data;
        }

        public async Task<ServiceResult<object>> RemoveAsync(string phoneNumber)
        {
            return await Task.Run(() => Remove(phoneNumber));
        }
    }
}
