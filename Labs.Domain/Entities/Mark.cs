namespace Labs.Domain.Entities
{
    public class Mark : Entity
    {
        public string EmployeId { get; private set; }
        public string EmployerId { get; private set; }
        public DateTime IncludedAt { get; private set; }

        public Mark() { }

        public Mark(string employeId, string employerId, DateTime includedAt)
        {
            EmployeId = employeId;
            EmployerId = employerId;
            IncludedAt = includedAt;
        }

    }
}
