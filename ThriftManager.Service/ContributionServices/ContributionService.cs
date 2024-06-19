using System;
using System.Threading.Tasks;
using ThriftManager.Infrastructure;

namespace ThriftManager.Service.ContributionServices
{
    public class ContributionService : IContributionService
    {
        private readonly IThriftAppDbContext _context;

        public ContributionService(IThriftAppDbContext context)
        {
            _context = context;
        }

        public async Task<Contribution> CreateContribution(string title, Group group)
        {
            var contribution = Contribution.Create(title, group);
            _context.Contributions.Add(contribution);
            await _context.SaveChangesAsync();
            return contribution;
        }

        public async Task InitWallet(long contributionId, string title, string walletNumber, BankAccount account)
        {
            var contribution = await _context.Contributions.FindAsync(contributionId);
            if (contribution == null)
                throw new InvalidOperationException("Contribution not found");

            contribution.InitWallet(title, walletNumber, account);
            await _context.SaveChangesAsync();
        }

        public async Task<ContributingMember> AddContributingMember(long contributionId, int memberId)
        {
            var contribution = await _context.Contributions.FindAsync(contributionId);
            if (contribution == null)
                throw new InvalidOperationException("Contribution not found");

            var member = contribution.AddContributingMember(memberId);
            await _context.SaveChangesAsync();
            return member;
        }

        public async Task MakeContribution(long contributionId, int memberId, decimal amount)
        {
            var contribution = await _context.Contributions.FindAsync(contributionId);
            if (contribution == null)
                throw new InvalidOperationException("Contribution not found");

            contribution.MakeContribution(memberId, amount);
            await _context.SaveChangesAsync();
        }
    }
}
