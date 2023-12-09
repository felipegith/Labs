using Labs.Domain.Entities;

namespace Labs.Domain.Comand.Utils
{
    public abstract class ModelComand : Entity
    {
        public string EmployeId { get; set; }
        public string EmployerId { get; set; }
        public DateTime IncludedAt { get; set; }
    }
}
