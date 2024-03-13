using GraphQL_API.DAO;
using GraphQL_API.Models;
using MongoDB.Driver;

namespace GraphQL_API.Services.Interfaces
{
    public interface IBookService
    {

        public List<Book> GetAllBooks();
        public Book GetBookByISBN(string isbn);

        public Book GetBookByTitle(string title);

    }
}
