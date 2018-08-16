using Comtele.Sdk.Core.Resources;
using Comtele.Sdk.Core.Services;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comtele.Sdk.Services
{
    public class ContactService : ServiceBase, IContactService
    {
        public ContactService(string apiKey) : base(apiKey) { }

        public ServiceResult<object> AddContactToGroup(string groupName, string contactPhone, string contactName)
        {
            var restClient = new RestClient(ENDPOINT_ADDRESS);
            var restRequest = new RestRequest("contactgroup", Method.PUT);

            restRequest.AddHeader("auth-key", ApiKey);
            restRequest.AddJsonBody(new { groupName, Action = "add_number", contactPhone, contactName });

            var restResponse = restClient.Execute<ServiceResult<object>>(restRequest);

            return restResponse.Data;
        }

        public async Task<ServiceResult<object>> AddContactToGroupAsync(string groupName, string contactPhone, string contactName)
        {
            return await Task.Run(() => AddContactToGroup(groupName, contactPhone, contactName));
        }

        public ServiceResult<object> CreateGroup(string groupName, string groupDescription)
        {
            var restClient = new RestClient(ENDPOINT_ADDRESS);
            var restRequest = new RestRequest("contactgroup", Method.POST);

            restRequest.AddHeader("auth-key", ApiKey);
            restRequest.AddJsonBody(new { Name = groupName, Description = groupDescription });

            var restResponse = restClient.Execute<ServiceResult<object>>(restRequest);

            return restResponse.Data;
        }

        public async Task<ServiceResult<object>> CreateGroupAsync(string groupName, string groupDescription)
        {
            return await Task.Run(() => CreateGroup(groupName, groupDescription));
        }

        public ServiceResult<List<ContactGroupResource>> GetAllGroups()
        {
            var restClient = new RestClient(ENDPOINT_ADDRESS);
            var restRequest = new RestRequest("contactgroup", Method.GET);

            restRequest.AddHeader("auth-key", ApiKey);

            var restResponse = restClient.Execute<ServiceResult<List<ContactGroupResource>>>(restRequest);
            return restResponse.Data;
        }

        public async Task<ServiceResult<List<ContactGroupResource>>> GetAllGroupsAsync()
        {
            return await Task.Run(() => GetAllGroups());
        }

        public ServiceResult<List<ContactGroupResource>> GetGroupByName(string groupName)
        {
            var restClient = new RestClient(ENDPOINT_ADDRESS);
            var restRequest = new RestRequest("contactgroup", Method.GET);

            restRequest.AddHeader("auth-key", ApiKey);
            restRequest.AddQueryParameter("id", groupName);

            var restResponse = restClient.Execute<ServiceResult<List<ContactGroupResource>>>(restRequest);
            return restResponse.Data;
        }

        public async Task<ServiceResult<List<ContactGroupResource>>> GetGroupByNameAsync(string groupName)
        {
            return await Task.Run(() => GetGroupByName(groupName));
        }

        public ServiceResult<object> RemoveContactFromGroup(string groupName, string contactPhone)
        {
            var restClient = new RestClient(ENDPOINT_ADDRESS);
            var restRequest = new RestRequest("contactgroup", Method.PUT);

            restRequest.AddHeader("auth-key", ApiKey);
            restRequest.AddJsonBody(new { groupName, Action = "remove_number", contactPhone });

            var restResponse = restClient.Execute<ServiceResult<object>>(restRequest);
            return restResponse.Data;
        }

        public async Task<ServiceResult<object>> RemoveContactFromGroupAsync(string groupName, string contactPhone)
        {
            return await Task.Run(() => RemoveContactFromGroup(groupName, contactPhone));
        }

        public ServiceResult<object> RemoveGroup(string groupName)
        {
            var restClient = new RestClient(ENDPOINT_ADDRESS);
            var restRequest = new RestRequest("contactgroup", Method.DELETE);

            restRequest.AddHeader("auth-key", ApiKey);
            restRequest.AddQueryParameter("id", groupName);

            var restResponse = restClient.Execute<ServiceResult<object>>(restRequest);
            return restResponse.Data;
        }

        public async Task<ServiceResult<object>> RemoveGroupAsync(string groupName)
        {
            return await Task.Run(() => RemoveGroup(groupName));
        }
    }
}
