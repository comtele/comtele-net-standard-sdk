using System;
using System.Threading.Tasks;
using Comtele.Sdk.Core.Resources;
using Comtele.Sdk.Core.Services;
using RestSharp;

namespace Comtele.Sdk.Services
{
    public class ContactMessageServicie : ServiceBase, IContactMessageService
    {
        public ContactMessageServicie(string apiKey) : base(apiKey) { }

        public ServiceResult<object> Schedule(string sender, string content, string groupName, DateTime scheduleDate)
        {
            var restClient = new RestClient(ENDPOINT_ADDRESS);
            var restRequest = new RestRequest("schedulecontactmessage", Method.POST);

            restRequest.AddHeader("auth-key", ApiKey);
            restRequest.AddJsonBody(new
            {
                sender,
                content,
                groupName,
                scheduleDate = $"{scheduleDate:yyyy-MM-dd HH:mm:ss}"
            });

            var restResponse = restClient.Execute<ServiceResult<object>>(restRequest);

            return restResponse.Data;
        }

        public async Task<ServiceResult<object>> ScheduleAsync(string sender, string content, string groupName, DateTime scheduleDate)
        {
            return await Task.Run(() => Schedule(sender, content, groupName, scheduleDate));
        }

        public ServiceResult<object> Send(string sender, string content, string groupName)
        {
            var restClient = new RestClient(ENDPOINT_ADDRESS);
            var restRequest = new RestRequest("sendcontactmessage", Method.POST);

            restRequest.AddHeader("auth-key", ApiKey);
            restRequest.AddJsonBody(new { sender, content, groupName });

            var restResponse = restClient.Execute<ServiceResult<object>>(restRequest);

            return restResponse.Data;
        }

        public async Task<ServiceResult<object>> SendAsync(string sender, string content, string groupName)
        {
            return await Task.Run(() => Send(sender, content, groupName));
        }
    }
}