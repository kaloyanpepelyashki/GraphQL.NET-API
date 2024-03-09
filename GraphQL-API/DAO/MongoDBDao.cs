using MongoDB.Driver;

namespace GraphQL_API.DAO
{
    public class MongoDBDao
    {
        protected static MongoDBDao instance;
        public IMongoClient client;
        protected readonly string _connectionString;
        protected readonly IConfiguration _configuration;

        protected MongoDBDao() { 
            try
            {
                _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").AddEnvironmentVariables().Build();
                _connectionString = _configuration.GetValue<string>("MongoDB:ConnectionString");
                client = new MongoClient(_connectionString);

            } catch (Exception e)
            {
                throw new Exception($"Error instantiating MongoDB DAO: {e}");
            }
        
        
        }

        public static MongoDBDao GetInstance()
        {
            if(instance == null)
            {
                instance = new MongoDBDao();
            }

            return instance;
        }

    }
}
