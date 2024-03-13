﻿using GraphQL_API.DAO;
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
            _databaseName = _mongoDBDao.client.GetDatabase("BookShelf");
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
                var collection = _databaseName?.GetCollection<Book>("ReadBooks");
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

        public Book GetBookByISBN(string isbn)
        {
            try
            {
                var collection = _databaseName?.GetCollection<Book>("ReadBooks");
                var filter = Builders<Book>.Filter.Eq("ISBN", isbn);

                var result = collection.Find(filter).First();

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

        public Book GetBookByTitle(string title)
        {
            try
            {
                var collection = _databaseName.GetCollection<Book>("ReadBooks");
                var filter = Builders<Book>.Filter.Eq("bookTitle", title);

                var result = collection.Find(filter).First();

                if(result != null)
                {
                    return result;
                }

                throw new Exception($"No book with the title {title} was found");

            } catch(Exception e) {


                throw new Exception($"Error getting {title}: {e}");
            }
        }
    }
}
