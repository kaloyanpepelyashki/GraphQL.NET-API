using GraphQL_API.Services.Interfaces;
using GraphQL_API.Services;
using GraphQL_API.Models;

namespace GraphQL_API.GraphQL.GraphQueries
{
    public class BooksToReadQuery
    {
        protected IBookService _bookService = BooksToReadService.GetInstance();

        public List<Book> GetAllBooks()
        {
            try
            {
                var books = _bookService.GetAllBooks();

                if (books.Count != 0)
                {
                    return books;
                }

                return [];
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting all books : {e}");
            }
        }


        public List<Book> GetAllToReadBooks()
        {
            try
            {
                var books = _bookService.GetAllBooks();

                if (books.Count != 0)
                {
                    return books;
                }

                return [];
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting all books : {e}");
            }
        }

        public Book GetBookByTite(string title)
        {

            try
            {
                var book = _bookService.GetBookByTitle(title);
                return book;

            }
            catch (Exception e)
            {
                throw new Exception($"Error getting book: {e}");
            }
        }

        public Book GetBookByISBN(string isbn)
        {
            try
            {
                var book = _bookService.GetBookByISBN(isbn);
                return book;
            }
            catch (Exception e)
            {
                throw new Exception($"Error getting book: {e}");
            }
        }
    }
}

