using Comtele.Sdk.Core.Resources;
using Comtele.Sdk.Core.Services;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comtele.Sdk.Services
{
    public class ReplyService : ServiceBase, IReplyService
    {
        public ReplyService(string apiKey)
            : base(apiKey)
        { }

        public ServiceResult<List<ReplyReportResource>> GetReport(DateTime startDate, DateTime endDate)
        {
            return GetReport(startDate, endDate, null);
        }

        public ServiceResult<List<ReplyReportResource>> GetReport(DateTime startDate, DateTime endDate, string sender)
        {            
            return GetReportAsync(startDate, endDate, sender).Result;
        }

        public Task<ServiceResult<List<ReplyReportResource>>> GetReportAsync(DateTime startDate, DateTime endDate)
        {
            return GetReportAsync(startDate, endDate, null);
        }

        public async Task<ServiceResult<List<ReplyReportResource>>> GetReportAsync(DateTime startDate, DateTime endDate, string sender)
        {
            var client = new RestClient(ENDPOINT_ADDRESS);
            var request = new RestRequest("replyreporting", Method.GET);

            request.AddHeader("auth-key", ApiKey);
            request.AddQueryParameter("startDate", $"{startDate:yyyy-MM-dd HH:mm:ss}");
            request.AddQueryParameter("endDate", $"{endDate:yyyy-MM-dd HH:mm:ss}");
            request.AddQueryParameter("sender", sender);

            var response = await client.ExecuteTaskAsync<ServiceResult<List<ReplyReportResource>>>(request);
            return response.Data;
        }
    }
}
