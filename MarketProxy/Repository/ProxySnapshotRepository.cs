using System.Collections.Generic;
using MarketProxy.Model;
using MongoDB.Driver;

namespace MarketProxy.Repository
{
    public interface IProxySnapshotRepository
    {
        List<MarketSnapshot> Get();
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

        public List<MarketSnapshot> Get() => _marketSnapshot.Find(x => true).ToList();
    }
}