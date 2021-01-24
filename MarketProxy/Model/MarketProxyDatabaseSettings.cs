namespace MarketProxy.Model
{
    public class MarketProxyDatabaseSettings : IMarketProxyDatabaseSettings
    {
        public string SnapshotCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IMarketProxyDatabaseSettings
    {
        string SnapshotCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}