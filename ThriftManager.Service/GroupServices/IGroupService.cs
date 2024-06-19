using System.Threading.Tasks;
using ThriftManager.DTO.Requests;
using ThriftManager.DTO.Common;

namespace ThriftManager.Services
{
    public interface IGroupService
    {
        Task<ServiceResponse> CreateGroupAsync(CreateGroupRequest request);
    }
}
