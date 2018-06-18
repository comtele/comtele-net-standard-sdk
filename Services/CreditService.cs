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
            var client = new RestClient(ENDPOINT_ADDRESS);
            var request = new RestRequest("credits", Method.PUT);

            request.AddHeader("auth-key", ApiKey);
            request.AddQueryParameter("id", username);
            request.AddQueryParameter("amount", amount.ToString());
            var response = client.Execute<ServiceResult<object>>(request);

            return response.Data;
        }

        public async Task<ServiceResult<object>> AddCreditsAsync(string username, int amount)
        {
            return await Task.Run(() => AddCredits(username, amount));
        }

        public int GetCredits(string username)
        {
            var client = new RestClient(ENDPOINT_ADDRESS);
            var request = new RestRequest("credits", Method.GET);

            request.AddHeader("auth-key", ApiKey);
            request.AddQueryParameter("id", username);
            var response = client.Execute<ServiceResult<string>>(request);

            int.TryParse(response.Data.Object, out int credits);
            return credits;
        }

        public async Task<int> GetCreditsAsync(string username)
        {
            return await Task.Run(() => GetCredits(username));
        }

        public int GetMyCredits()
        {
            var client = new RestClient(ENDPOINT_ADDRESS);
            var request = new RestRequest("credits", Method.GET);

            request.AddHeader("auth-key", ApiKey);
            var response = client.Execute<ServiceResult<string>>(request);

            int.TryParse(response.Data.Object, out int credits);
            return credits;
        }

        public async Task<int> GetMyCreditsAsync()
        {
            return await Task.Run(() => GetMyCredits());
        }

        public ServiceResult<List<CreditHistoryResource>> GetHistory(string username)
        {
            var client = new RestClient(ENDPOINT_ADDRESS);
            var request = new RestRequest("balancehistory", Method.GET);

            request.AddHeader("auth-key", ApiKey);
            request.AddQueryParameter("id", username);

            var response = client.Execute<ServiceResult<List<CreditHistoryResource>>>(request);
            return response.Data;
        }

        public async Task<ServiceResult<List<CreditHistoryResource>>> GetHistoryAsync(string username)
        {
            return await Task.Run(() => GetHistory(username));
        }
    }
}
