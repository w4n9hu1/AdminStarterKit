namespace AdminStarterKit.Domain.Aggregates
{
    public class Role : Entity, IAggregateRoot
    {
        public string RoleName { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public int CreatedBy { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
