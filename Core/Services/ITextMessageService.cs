using Comtele.Sdk.Core.Resources;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Comtele.Sdk.Core.Services
{
    public interface ITextMessageService
    {
        ServiceResult<object> Send(string sender, string content, params string[] receivers);
        Task<ServiceResult<object>> SendAsync(string sender, string content, params string[] receivers);

        ServiceResult<object> Schedule(string sender, string content, DateTime scheduleDate, params string[] receivers);
        Task<ServiceResult<object>> ScheduleAsync(string sender, string content, DateTime scheduleDate, params string[] receivers);

        ServiceResult<List<DetailedReportResource>> GetDetailedReport(DateTime startDate, DateTime endDate, DeliveryStatus deliveryStatus);
        Task<ServiceResult<List<DetailedReportResource>>> GetDetailedReportAsync(DateTime startDate, DateTime endDate, DeliveryStatus deliveryStatus);

        ServiceResult<List<ConsolidatedReportResource>> GetConsolidatedReport(DateTime startDate, DateTime endDate, ReportGroupType groupType);
        Task<ServiceResult<List<ConsolidatedReportResource>>> GetConsolidatedReportAsync(DateTime startDate, DateTime endDate, ReportGroupType groupType);
    }
}
