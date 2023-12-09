namespace Labs.Aplication.Dto
{
    public class MarkDTO 
    {
        public string EmployeId { get; set; }
        public string EmployerId { get; set; }
        public DateTime IncludedAt { get; set; } = DateTime.Now;

    }
}
