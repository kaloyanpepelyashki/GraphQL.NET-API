using DnsClient;
using GraphQL;
using GraphQL.Types;
using GraphQL_API.GraphQL.GraphTypes;
using GraphQL_API.Models;
using GraphQL_API.Services;
using GraphQL_API.Services.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace GraphQL_API.GraphQL.GraphQueries
{
    public class BooksQuery
    {
        protected IBookService _bookService = BooksService.GetInstance();
       public List<Book> getAllBooks()
       {
            try
            {
                var books = _bookService.GetAllBooks();

                if (books.Count != 0)
                {
                    return books;
                }

                return [];
            } catch(Exception e)
            {
                throw new Exception($"Error getting all books : {e}");
            }
       }
    }
}
    