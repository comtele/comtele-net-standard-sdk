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
            var client = new RestClient(ENDPOINT_ADDRESS);
            var request = new RestRequest("accounts", Method.GET);

            request.AddHeader("auth-key", ApiKey);
            request.AddQueryParameter("id", username);

            var response = client.Execute<ServiceResult<List<AccountDetailResource>>>(request);
            return response.Data?.Object?.FirstOrDefault();
        }

        public async Task<AccountDetailResource> GetAccountByUsernameAsync(string username)
        {
            return await Task.Run(() => GetAccountByUsername(username));
        }

        public ServiceResult<List<AccountDetailResource>> GetAllAccounts()
        {            
            var client = new RestClient(ENDPOINT_ADDRESS);
            var request = new RestRequest("accounts", Method.GET);

            request.AddHeader("auth-key", ApiKey);

            var response = client.Execute<ServiceResult<List<AccountDetailResource>>>(request);
            return response.Data;
        }

        public async Task<ServiceResult<List<AccountDetailResource>>> GetAllAccountsAsync()
        {
            return await Task.Run(() => GetAllAccounts());
        }
    }
}
