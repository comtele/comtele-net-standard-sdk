using Comtele.Sdk.Core.Resources;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Comtele.Sdk.Core.Services
{
    public interface IContactService
    {
        ServiceResult<object> CreateGroup(string groupName, string groupDescription);
        Task<ServiceResult<object>> CreateGroupAsync(string groupName, string groupDescription);

        ServiceResult<List<ContactGroupResource>> GetAllGroups();
        Task<ServiceResult<List<ContactGroupResource>>> GetAllGroupsAsync();

        ServiceResult<List<ContactGroupResource>> GetGroupByName(string groupName);
        Task<ServiceResult<List<ContactGroupResource>>> GetGroupByNameAsync(string groupName);

        ServiceResult<object> RemoveGroup(string groupName);
        Task<ServiceResult<object>> RemoveGroupAsync(string groupName);

        ServiceResult<object> AddContactToGroup(string groupName, string contactPhone, string contactName);
        Task<ServiceResult<object>> AddContactToGroupAsync(string groupName, string contactPhone, string contactName);

        ServiceResult<object> RemoveContactFromGroup(string groupName, string contactPhone);
        Task<ServiceResult<object>> RemoveContactFromGroupAsync(string groupName, string contactPhone);
    }
}
