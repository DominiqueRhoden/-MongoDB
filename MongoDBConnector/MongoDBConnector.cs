using MongoDB.Driver;

namespace MongoDBConnector
{
    public class MongoDBConnector
    {
        public bool Ping()
        {
            try
            {
                _client.ListDatabaseNames(); // lightweight query
                return true;
            }
            catch
            {
                return false;
            }
        }

        private readonly IMongoClient _client;

        public MongoDBConnector(string connectionString)
        {
            _client = new MongoClient(connectionString);
        }
    }
}
    