using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ThriftManager.DTO.Requests;
using ThriftManager.DTO.Common;

namespace ThriftManager.Services
{
    public class GroupServices : IGroupService
    {
        private readonly IThriftAppDbContext _dbContext;

        public GroupServices(IThriftAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ServiceResponse> CreateGroupAsync(CreateGroupRequest request)
        {
            var group = new Group
            {
                Name = request.Name,
                Title = request.Title,
                Amount = request.Amount,
                Timeline = ContributionTimeline.Create(request.Slots, request.Period, request.Tenure, request.DueDay)
            };

            _dbContext.Groups.Add(group);
            await _dbContext.SaveChangesAsync();

            return new ServiceResponse { IsSuccessful = true };
        }


    }
}
