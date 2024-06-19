namespace ThriftManager.Web.Models
{
    public class SuccessViewModel
    {
        public string MemberName { get; set; }
        public List<string> ContributionMenus { get; set; }
        public List<GroupViewModel> Groups { get; set; }
    }

    public class GroupViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
    }
}
