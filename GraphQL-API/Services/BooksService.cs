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
        protected IMongoDatabase _database;
        protected IMongoCollection<Book> _collection;

        protected BooksService()
        {
            _mongoDBDao = MongoDBDao.GetInstance();
            _database = _mongoDBDao.client.GetDatabase("BookShelf");
            _collection = _database.GetCollection<Book>("ReadBooks");
        }

        public static BooksService GetInstance()
        {
            if(instance == null)
            {
                instance = new BooksService();
            }

            return instance;
        }

        /** 
       * Gets all books and returns a list of Book objects
       */ 
        public List<Book> GetAllBooks()
        {
            try
            {
                
                var result = _collection.Find(new BsonDocument()).ToList();

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
        /**
      * Gets a book by isbn and returns a Book object, accepts a parameter of type string title
      */
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
                throw new Exception($"Error getting book with ISBN {isbn}: {e}");
            }
        }
        /**
       * Gets a book by title and returns a Book object, accepts a parameter of type string title
       */
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

            } catch(Exception e) {


                throw new Exception($"Error getting {title}: {e}");
            }
        }

        /**
         * Inserts a book into the BooksToRead collection
         */
        public async Task<bool> InsertBook(Book newBook)
        {
            try
            {
                var bookMatch = await _collection.Find(book => book.Title == newBook.Title && book.Author == newBook.Author).FirstOrDefaultAsync();

                if(bookMatch == null)
                {
                    await _collection.InsertOneAsync(newBook);
                    return true;
                }

                throw new Exception("Book already exists");
            } catch(Exception e)
            {
                throw new Exception($"Error inserting book: {e}");
            }
        }
    }
}
