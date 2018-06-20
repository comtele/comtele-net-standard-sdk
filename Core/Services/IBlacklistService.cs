using Comtele.Sdk.Core.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comtele.Sdk.Core.Services
{
    public interface IBlacklistService
    {
        ServiceResult<object> Insert(string phoneNumber);
        ServiceResult<object> Remove(string phoneNumber);
        ServiceResult<List<BlacklistResource>> GetBlacklist();
        BlacklistResource GetByPhoneNumber(string phoneNumber);        


        Task<ServiceResult<object>> InsertAsync(string phoneNumber);
        Task<ServiceResult<object>> RemoveAsync(string phoneNumber);
        Task<ServiceResult<List<BlacklistResource>>> GetBlacklistAsync();
        Task<BlacklistResource> GetByPhoneNumberAsync(string phoneNumber);
    }
}
