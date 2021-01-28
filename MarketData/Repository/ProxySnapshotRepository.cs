using System.Collections.Generic;
using System.Threading.Tasks;
using MarketData.Config;
using MarketData.Model;
using MongoDB.Driver;

namespace MarketData.Repository
{
    public interface IProxySnapshotRepository
    {
        Task<List<MarketSnapshot>> Get();
        Task<MarketSnapshot> Find(string id);
        Task<MarketSnapshot> FindByName(string name);
    }

    public class ProxySnapshotRepository : IProxySnapshotRepository
    {
        private readonly IMongoCollection<MarketSnapshot> _marketSnapshot;

        public ProxySnapshotRepository(IMarketProxyDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            this._marketSnapshot = database.GetCollection<MarketSnapshot>(settings.SnapshotCollectionName);
        }

        public async Task<List<MarketSnapshot>> Get() => await _marketSnapshot.Find(x => true).ToListAsync();

        public async Task<MarketSnapshot> Find(string id) =>
            await _marketSnapshot.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<MarketSnapshot> FindByName(string name) =>
            await _marketSnapshot.Find(x => x.Name == name).FirstOrDefaultAsync();
    }
}