using Labs.Domain.Entities;
using Labs.Domain.Interfaces;
using Labs.Infra.Database;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Labs.Infra.Repositories
{
    public class MarkRepository : IMarkRepository
    {
        private readonly IMongoCollection<Mark> _mongoCollection;

        public MarkRepository(IOptions<Settings> dataBaseSettings)
        {
            var mongoClient = new MongoClient(dataBaseSettings.Value.ConnectionString);
            var mongodb = mongoClient.GetDatabase(dataBaseSettings.Value.DatabaseName);
            _mongoCollection = mongodb.GetCollection<Mark>(dataBaseSettings.Value.CollectionName);
        }
        public async Task<Mark> CreateAsync(Mark mark, CancellationToken cancellationToken)
        {
            await _mongoCollection.InsertOneAsync(mark);
            return mark;
        }

        public async Task<IEnumerable<Mark>> FindAllEmployerAsync(string employerId, CancellationToken cancellationToken)
        {
            var findAllEmployerMark = await _mongoCollection.Find(x => x.EmployerId == employerId).ToListAsync();

            return findAllEmployerMark;
        }

        public async Task<IEnumerable<Mark>> FindAllEmployeMarkAsync(string employeId, CancellationToken cancellationToken)
        {
            var findAllEmployeMark = await _mongoCollection.Find(x => x.EmployeId == employeId).ToListAsync();

            return findAllEmployeMark;
        }
    }
}
