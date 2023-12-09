using Labs.Domain.Entities;

namespace Labs.Domain.Interfaces
{
    public interface IMarkRepository
    {
        Task<Mark> CreateAsync(Mark mark, CancellationToken cancellationToken);
        Task <IEnumerable<Mark>> FindAllEmployerAsync(string employerId, CancellationToken cancellationToken);
        Task <IEnumerable<Mark>> FindAllEmployeMarkAsync(string employeId, CancellationToken cancellationToken);
    }
}
