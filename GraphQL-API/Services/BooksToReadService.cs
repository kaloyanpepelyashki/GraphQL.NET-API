using GraphQL_API.DAO;
using GraphQL_API.Models;
using GraphQL_API.Services.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace GraphQL_API.Services
{
    public class BooksToReadService:IBookService
    {
        private static BooksToReadService instance;
        protected MongoDBDao _mongoDBDao;
        protected IMongoDatabase _database;
        protected IMongoCollection<Book> _collection;

        protected BooksToReadService() 
        {
            _mongoDBDao = MongoDBDao.GetInstance();
            _database = _mongoDBDao.client.GetDatabase("BookShelf");
            _collection = _database.GetCollection<Book>("BooksToRead");
        }

        public static BooksToReadService GetInstance()
        {
            if(instance == null)
            {
                instance = new BooksToReadService();
            }

            return instance;
        }

        public List<Book> GetAllBooks()
        {
            try
            {

                var result = _collection.Find(new BsonDocument()).ToList();

                if(result.Count != 0)
                {
                    return result;
                }

                return [];

            } catch(Exception e)
            {
                throw new Exception($"Error getting books: {e}");
            }
        }

        public Book GetBookByISBN(string isbn)
        {
            try
            {
                var filter = Builders<Book>.Filter.Eq("ISBN", isbn);
                var result = _collection.Find(filter).First();


                if (result != null)
                {
                    return result;
                }

                return null;
            } catch(Exception e)
            {
                throw new Exception($"Error getting book with ISBN: {isbn}: {e}");
            }
        }

        public Book GetBookByTitle(string title)
        {
            try
            {
                var filter = Builders<Book>.Filter.Eq("bookTitle", title);
                var result = _collection.Find(filter).First();

                if(result != null)
                {
                    return result;
                }

                throw new Exception($"No book with the title {title} was found");
            } catch(Exception e)
            {
                throw new Exception($"Error getting {title}: {e}");
            }
        }
    }
}
