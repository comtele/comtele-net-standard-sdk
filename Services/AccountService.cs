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
    public class AccountService : ServiceBase, IAccountService
    {
        public AccountService(string apiKey)
            : base(apiKey)
        { }

        public AccountDetailResource GetAccountByUsername(string username)
        {
            return GetAccountByUsernameAsync(username).Result;
        }

        public async Task<AccountDetailResource> GetAccountByUsernameAsync(string username)
        {
            var client = new RestClient(ENDPOINT_ADDRESS);
            var request = new RestRequest("accounts", Method.GET);

            request.AddHeader("auth-key", ApiKey);
            request.AddQueryParameter("id", username);

            var response = await client.ExecuteTaskAsync<ServiceResult<List<AccountDetailResource>>>(request);
            return response.Data?.Object?.FirstOrDefault();
        }

        public ServiceResult<List<AccountDetailResource>> GetAllAccounts()
        {
            return GetAllAccountsAsync().Result;
        }

        public async Task<ServiceResult<List<AccountDetailResource>>> GetAllAccountsAsync()
        {
            var client = new RestClient(ENDPOINT_ADDRESS);
            var request = new RestRequest("accounts", Method.GET);

            request.AddHeader("auth-key", ApiKey);            

            var response = await client.ExecuteTaskAsync<ServiceResult<List<AccountDetailResource>>>(request);
            return response.Data;
        }
    }
}
