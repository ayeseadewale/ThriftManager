
namespace ThriftManager.Service.MemberServices;

public interface IMemberService
{
    Task<ServiceResponse<MemberIdResponse>> CreateMember(CreateMemberRequest request);
    //Task<ServiceResponse<IEnumerable<MemberIdResponse>>> GetAllMembers();
    Task<List<string>> GetContributionMenus();
}
