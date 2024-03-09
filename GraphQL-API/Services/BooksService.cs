using GraphQL_API.DAO;
using GraphQL_API.Models;
using GraphQL_API.Services.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections;

namespace GraphQL_API.Services
{
    public class BooksService:IBookService
    {
        private static BooksService instance;
        protected MongoDBDao _mongoDBDao;
        protected IMongoDatabase _databaseName;

        protected BooksService()
        {
            _mongoDBDao = MongoDBDao.GetInstance();
            _databaseName = _mongoDBDao.client.GetDatabase("Books");
        }

        public static BooksService GetInstance()
        {
            if(instance == null)
            {
                instance = new BooksService();
            }

            return instance;
        }

        public List<Book> GetAllBooks()
        {
            try
            {
                var collection = _databaseName?.GetCollection<Book>("Books");
                var result = collection.Find(new BsonDocument()).ToList();

                if (result.Count == 0)
                {
                    return null;
                }

                return result;
            } catch(Exception e)
            {
                throw new Exception($"Error getting all books: {e}");
            }
        }
    }
}
