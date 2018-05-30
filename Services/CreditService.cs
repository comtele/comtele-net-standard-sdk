using Comtele.Sdk.Core.Resources;
using Comtele.Sdk.Core.Services;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comtele.Sdk.Services
{
    public class CreditService : ServiceBase, ICreditService
    {
        public CreditService(string apiKey)
            : base(apiKey)
        { }

        public ServiceResult<object> AddCredits(string username, int amount)
        {
            return AddCreditsAsync(username, amount).Result;
        }

        public async Task<ServiceResult<object>> AddCreditsAsync(string username, int amount)
        {
            var client = new RestClient(ENDPOINT_ADDRESS);
            var request = new RestRequest("credits", Method.PUT);

            request.AddHeader("auth-key", ApiKey);
            request.AddQueryParameter("id", username);
            request.AddQueryParameter("amount", amount.ToString());
            var response = await client.ExecuteTaskAsync<ServiceResult<object>>(request);

            return response.Data;
        }

        public int GetCredits(string username)
        {
            return GetCreditsAsync(username).Result;
        }

        public async Task<int> GetCreditsAsync(string username)
        {
            var client = new RestClient(ENDPOINT_ADDRESS);
            var request = new RestRequest("credits", Method.GET);

            request.AddHeader("auth-key", ApiKey);
            request.AddQueryParameter("id", username);
            var response = await client.ExecuteTaskAsync<ServiceResult<string>>(request);

            int.TryParse(response.Data.Object, out int credits);
            return credits;
        }

        public int GetMyCredits()
        {
            return GetMyCreditsAsync().Result;
        }

        public async Task<int> GetMyCreditsAsync()
        {
            var client = new RestClient(ENDPOINT_ADDRESS);
            var request = new RestRequest("credits", Method.GET);

            request.AddHeader("auth-key", ApiKey);
            var response = await client.ExecuteTaskAsync<ServiceResult<string>>(request);

            int.TryParse(response.Data.Object, out int credits);
            return credits;
        }

        public ServiceResult<List<CreditHistoryResource>> GetHistory(string username)
        {
            return GetHistoryAsync(username).Result;
        }

        public async Task<ServiceResult<List<CreditHistoryResource>>> GetHistoryAsync(string username)
        {
            var client = new RestClient(ENDPOINT_ADDRESS);
            var request = new RestRequest("balancehistory", Method.GET);

            request.AddHeader("auth-key", ApiKey);
            request.AddQueryParameter("id", username);

            var response = await client.ExecuteTaskAsync<ServiceResult<List<CreditHistoryResource>>>(request);
            return response.Data;
        }
    }
}
