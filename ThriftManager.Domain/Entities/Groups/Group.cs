namespace ThriftManager.Domain.Entities;

public class Group
{
    public int GroupId { get;  set; }
    public string Name { get;  set; } = default!;
    public string Title { get;  set; } = default!;
    public decimal Amount { get;  set; }
    public ContributionTimeline Timeline { get;  set; } = ContributionTimeline.Default();
    public ItemStatus Status { get;  set; }
    public int CreatedBy { get;  set; }
    public DateTime CreatedOn { get;  set; }
    public DateTime? UpdatedOn { get;  set; }

    public HashSet<Contribution> Contributions { get;  set; } = new HashSet<Contribution>();

    public Group() { }
    private Group(string name, string title, ContributionTimeline timeline, decimal amount)
    {
        Name = name;
        Title = title;
        Timeline = timeline;
        Amount = amount;
        Status = ItemStatus.Active;
        CreatedBy = 1;
        CreatedOn = DateTime.UtcNow;
    }

    public static Group Create(string name, string title, ContributionTimeline timeline, decimal amount)
    {
        return new Group(name, title, timeline, amount);
    }
}
