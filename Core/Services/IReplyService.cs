using Comtele.Sdk.Core.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comtele.Sdk.Core.Services
{
    public interface IReplyService
    {
        ServiceResult<List<ReplyReportResource>> GetReport(DateTime startDate, DateTime endDate);
        ServiceResult<List<ReplyReportResource>> GetReport(DateTime startDate, DateTime endDate, string sender);

        Task<ServiceResult<List<ReplyReportResource>>> GetReportAsync(DateTime startDate, DateTime endDate);
        Task<ServiceResult<List<ReplyReportResource>>> GetReportAsync(DateTime startDate, DateTime endDate, string sender);
    }
}
