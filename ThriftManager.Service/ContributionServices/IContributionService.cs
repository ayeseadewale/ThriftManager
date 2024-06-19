using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThriftManager.Service.ContributionServices
{
    public interface IContributionService
    {
        Task<Contribution> CreateContribution(string title, Group group);
        Task InitWallet(long contributionId, string title, string walletNumber, BankAccount account);
        Task<ContributingMember> AddContributingMember(long contributionId, int memberId);
        Task MakeContribution(long contributionId, int memberId, decimal amount);
    }
}
