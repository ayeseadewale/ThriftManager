using Microsoft.EntityFrameworkCore;
using ThriftManager.Domain.Entities;

namespace ThriftManager.Infrastructure;

public class ThriftAppDbContext : DbContext, IThriftAppDbContext
{
    internal const string DEFAULT_SCHEMA = "ThriftSchema";
    private string? _conString = "";

    //IConfiguration configuration
    public ThriftAppDbContext()
    {
        _conString = "server=ADEWALE\\SQLEXPRESS; Initial Catalog=ThirftManagerDb; Integrated Security=True; Pooling=False; TrustServerCertificate=True";
        //_conString = configuration.GetConnectionString("PGLocalTestBed");
        //if (!string.IsNullOrEmpty(_conString) && _conString.Length > 5)
        //{
        //    _conString = _conString.Replace("{{DBName}}", "ThriftAppDB");
        //}
        //else
        //{
        //    _conString = "PORT=5433;HOST=localhost;DATABASE=ThriftAppDB;USER ID=postgres;PASSWORD=s3alt3am";
        //}
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     => optionsBuilder
     .UseSqlServer(_conString)
     .EnableSensitiveDataLogging();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(DEFAULT_SCHEMA);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ThriftAppDbContext).Assembly);
    }

    public DbSet<Member> Members { get; set; }
    public DbSet<MemberWallet> MemberWallets { get; set; }
    public DbSet<MemberWalletTransaction> MemberWalletTransactions { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Contribution> Contributions { get; set; }
    public DbSet<ContributingMember> ContributingMembers { get; set; }
    public DbSet<ContributionWallet> ContributionWallets { get; set; }
    public DbSet<ContributionWalletTransaction> ContributionWalletTransactions { get; set; }

}
