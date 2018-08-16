using Comtele.Sdk.Core.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comtele.Sdk.Core.Services
{
    public interface ITokenService
    {
        ServiceResult<object> SendToken(string phoneNumber, string prefix);
        Task<ServiceResult<object>> SendTokenAsync(string phoneNumber, string prefix);

        ServiceResult<object> SendToken(string phoneNumber);
        Task<ServiceResult<object>> SendTokenAsync(string phoneNumber);

        ServiceResult<object> ValidateToken(string tokenCode);
        Task<ServiceResult<object>> ValidateTokenAsync(string tokenCode);
    }
}
