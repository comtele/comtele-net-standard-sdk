using Comtele.Sdk.Core.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comtele.Sdk.Core.Services
{
    public interface IContactMessageService
    {
        ServiceResult<object> Send(string sender, string content, string groupName);
        Task<ServiceResult<object>> SendAsync(string sender, string content, string groupName);

        ServiceResult<object> Schedule(string sender, string content, string groupName, DateTime scheduleDate);
        Task<ServiceResult<object>> ScheduleAsync(string sender, string content, string groupName, DateTime scheduleDate);
    }
}
