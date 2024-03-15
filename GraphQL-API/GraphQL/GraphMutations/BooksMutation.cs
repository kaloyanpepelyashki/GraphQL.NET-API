using GraphQL_API.Services.Interfaces;
using GraphQL_API.Services;
using GraphQL_API.GraphQL.GraphTypes;
using GraphQL_API.Models;

namespace GraphQL_API.GraphQL.GraphMutations
{
    public class BooksMutation
    {
        protected IBookService _bookService = BooksService.GetInstance();


        public Book CreateBook(string bookIsbn, string bookTitle, string bookDescriptio, string bookAuthor)
        {
            try
            {
                var book = new Book(bookIsbn, bookTitle, bookDescriptio, bookAuthor);
                _bookService.InsertBook(book);

                return book;

            } catch (Exception e)
            {
                throw new Exception($"Error: {e}");
            }

        }

        internal object? AddABook(object value)
        {
            throw new NotImplementedException();
        }
    }
}
