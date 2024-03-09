using GraphQL_API.Models;

namespace GraphQL_API.Services.Interfaces
{
    public interface IBookService
    {
        public List<Book> GetAllBooks();
    }
}
