namespace Order.Infrastructure.Settings
{
    public interface IMongoDbSettings
    {
        public string OrderCollectionName { get; set; }
        public string OrderItemCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
