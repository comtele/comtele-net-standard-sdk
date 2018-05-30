using Comtele.Sdk.Core.Resources;
using Comtele.Sdk.Core.Services;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Comtele.Sdk.Services
{
    public class ContextMessageService : ServiceBase, IContextMessageService
    {
        public ContextMessageService(string apiKey)
            : base(apiKey)
        { }

        public ServiceResult<object> Send(string sender, string contextRuleName, params string[] receivers)
        {
            return SendAsync(sender, contextRuleName, receivers).Result;
        }

        public async Task<ServiceResult<object>> SendAsync(string sender, string contextRuleName, params string[] receivers)
        {
            var restClient = new RestClient(ENDPOINT_ADDRESS);
            var restRequest = new RestRequest("sendcontextmessage", Method.POST);

            restRequest.AddHeader("auth-key", ApiKey);
            restRequest.AddJsonBody(new
            {
                sender,
                contextRuleName,
                receivers = string.Join(",", receivers)
            });

            var restResponse = await restClient.ExecuteTaskAsync<ServiceResult<object>>(restRequest);

            return restResponse.Data;
        }

        public ServiceResult<object> Schedule(string sender, string contextRuleName, DateTime scheduleDate, params string[] receivers)
        {
            return ScheduleAsync(sender, contextRuleName, scheduleDate, receivers).Result;
        }

        public async Task<ServiceResult<object>> ScheduleAsync(string sender, string contextRuleName, DateTime scheduleDate, params string[] receivers)
        {
            var restClient = new RestClient(ENDPOINT_ADDRESS);
            var restRequest = new RestRequest("schedulecontextmessage", Method.POST);

            restRequest.AddHeader("auth-key", ApiKey);
            restRequest.AddJsonBody(new
            {
                sender,
                contextRuleName,
                scheduleDate = $"{scheduleDate:yyyy-MM-dd HH:mm:ss}",
                receivers = string.Join(",", receivers)
            });

            var restResponse = await restClient.ExecuteTaskAsync<ServiceResult<object>>(restRequest);

            return restResponse.Data;
        }

        public ServiceResult<List<ContextReportResource>> GetReport(DateTime startDate, DateTime endDate)
        {
            return GetReport(startDate, endDate, null, null);
        }

        public ServiceResult<List<ContextReportResource>> GetReport(DateTime startDate, DateTime endDate, string sender)
        {
            return GetReport(startDate, endDate, sender, null);
        }

        public ServiceResult<List<ContextReportResource>> GetReport(DateTime startDate, DateTime endDate, string sender, string contextRuleName)
        {
            return GetReportAsync(startDate, endDate, sender, contextRuleName).Result;
        }

        public Task<ServiceResult<List<ContextReportResource>>> GetReportAsync(DateTime startDate, DateTime endDate)
        {
            return GetReportAsync(startDate, endDate, null, null);
        }

        public Task<ServiceResult<List<ContextReportResource>>> GetReportAsync(DateTime startDate, DateTime endDate, string sender)
        {
            return GetReportAsync(startDate, endDate, sender, null);
        }

        public async Task<ServiceResult<List<ContextReportResource>>> GetReportAsync(DateTime startDate, DateTime endDate, string sender, string contextRuleName)
        {
            var client = new RestClient(ENDPOINT_ADDRESS);
            var request = new RestRequest("contextreporting", Method.GET);

            request.AddHeader("auth-key", ApiKey);

            request.AddQueryParameter("sender", sender);
            request.AddQueryParameter("contextRuleName", contextRuleName);
            request.AddQueryParameter("startDate", $"{startDate:yyyy-MM-dd HH:mm:ss}");
            request.AddQueryParameter("endDate", $"{endDate:yyyy-MM-dd HH:mm:ss}");

            var response = await client.ExecuteTaskAsync<ServiceResult<List<ContextReportResource>>>(request);
            return response.Data;
        }
    }
}
