using Comtele.Sdk.Core.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comtele.Sdk.Core.Services
{
    public interface ITokenService
    {
        ServiceResult<object> SendToken(string phoneNumber, string prefix, bool enforceSecureValidation);
        Task<ServiceResult<object>> SendTokenAsync(string phoneNumber, string prefix, bool enforceSecureValidation);

        ServiceResult<object> SendToken(string phoneNumber, bool enforceSecureValidation);
        Task<ServiceResult<object>> SendTokenAsync(string phoneNumber, bool enforceSecureValidation);

        ServiceResult<object> ValidateToken(string tokenCode, string phoneNumber);
        Task<ServiceResult<object>> ValidateTokenAsync(string tokenCode, string phoneNumber);
    }
}
