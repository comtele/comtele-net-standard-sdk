using Comtele.Sdk.Core.Resources;
using Comtele.Sdk.Core.Services;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comtele.Sdk.Services
{
    public class TextMessageService : ServiceBase, ITextMessageService
    {
        public TextMessageService(string apiKey)
            : base(apiKey)
        { }

        public ServiceResult<object> Send(string sender, string content, params string[] receivers)
        {
            return SendAsync(sender, content, receivers).Result;
        }

        public async Task<ServiceResult<object>> SendAsync(string sender, string content, params string[] receivers)
        {
            var restClient = new RestClient(ENDPOINT_ADDRESS);
            var restRequest = new RestRequest("send", Method.POST);

            restRequest.AddHeader("auth-key", ApiKey);
            restRequest.AddJsonBody(new
            {
                sender,
                content,
                receivers = string.Join(",", receivers)
            });

            var restResponse = await restClient.ExecuteTaskAsync<ServiceResult<object>>(restRequest);

            return restResponse.Data;
        }

        public ServiceResult<object> Schedule(string sender, string content, DateTime scheduleDate, params string[] receivers)
        {
            return ScheduleAsync(sender, content, scheduleDate, receivers).Result;
        }

        public async Task<ServiceResult<object>> ScheduleAsync(string sender, string content, DateTime scheduleDate, params string[] receivers)
        {
            var restClient = new RestClient(ENDPOINT_ADDRESS);
            var restRequest = new RestRequest("schedule", Method.POST);

            restRequest.AddHeader("auth-key", ApiKey);
            restRequest.AddJsonBody(new
            {
                sender,
                content,
                receivers = string.Join(",", receivers),
                scheduleDate = $"{scheduleDate:yyyy-MM-dd HH:mm:ss}"
            });

            var restResponse = await restClient.ExecuteTaskAsync<ServiceResult<object>>(restRequest);

            return restResponse.Data;
        }

        public ServiceResult<List<DetailedReportResource>> GetDetailedReport(DateTime startDate, DateTime endDate, DeliveryStatus deliveryStatus)
        {
            return GetDetailedReportAsync(startDate, endDate, deliveryStatus).Result;
        }

        public async Task<ServiceResult<List<DetailedReportResource>>> GetDetailedReportAsync(DateTime startDate, DateTime endDate, DeliveryStatus deliveryStatus)
        {
            var client = new RestClient(ENDPOINT_ADDRESS);
            var request = new RestRequest("detailedreporting", Method.GET);

            request.AddHeader("auth-key", ApiKey);
            request.AddQueryParameter("startDate", $"{startDate:yyyy-MM-dd HH:mm:ss}");
            request.AddQueryParameter("endDate", $"{endDate:yyyy-MM-dd HH:mm:ss}");

            var deliveryStatusAsString = DeliveryStatusToString(deliveryStatus);
            request.AddQueryParameter("delivered", deliveryStatusAsString);

            var response = await client.ExecuteTaskAsync<ServiceResult<List<DetailedReportResource>>>(request);
            return response.Data;
        }

        public ServiceResult<List<ConsolidatedReportResource>> GetConsolidatedReport(DateTime startDate, DateTime endDate, ReportGroupType groupType)
        {
            return GetConsolidatedReportAsync(startDate, endDate, groupType).Result;
        }

        public async Task<ServiceResult<List<ConsolidatedReportResource>>> GetConsolidatedReportAsync(DateTime startDate, DateTime endDate, ReportGroupType groupType)
        {
            var client = new RestClient(ENDPOINT_ADDRESS);
            var request = new RestRequest("consolidatedreporting", Method.GET);

            request.AddHeader("auth-key", ApiKey);
            request.AddQueryParameter("startDate", $"{startDate:yyyy-MM-dd HH:mm:ss}");
            request.AddQueryParameter("endDate", $"{endDate:yyyy-MM-dd HH:mm:ss}");

            var groupTypeAsString = ReportGroupTypeToString(groupType);
            request.AddQueryParameter("group", groupTypeAsString);

            var response = await client.ExecuteTaskAsync<ServiceResult<List<ConsolidatedReportResource>>>(request);
            
            return response.Data;
        }

        private string DeliveryStatusToString(DeliveryStatus deliveryStatus)
        {
            switch (deliveryStatus)
            {
                case DeliveryStatus.All:
                    return "all";
                case DeliveryStatus.Delivered:
                    return "true";
                case DeliveryStatus.Undelivered:
                    return "false";
                default:
                    return "all";
            }
        }

        private string ReportGroupTypeToString(ReportGroupType groupType)
        {
            switch (groupType)
            {
                case ReportGroupType.Monthly:
                    return "true";
                case ReportGroupType.Daily:
                    return "false";
                default:
                    return "true";
            }
        }
    }
}
