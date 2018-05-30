using Comtele.Sdk.Core.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comtele.Sdk.Core.Services
{
    public interface ICreditService
    {
        int GetMyCredits();
        Task<int> GetMyCreditsAsync();

        int GetCredits(string username);
        Task<int> GetCreditsAsync(string username);

        ServiceResult<object> AddCredits(string username, int amount);
        Task<ServiceResult<object>> AddCreditsAsync(string username, int amount);

        ServiceResult<List<CreditHistoryResource>> GetHistory(string username);
        Task<ServiceResult<List<CreditHistoryResource>>> GetHistoryAsync(string username);
    }
}
