using GraphQL;
using GraphQL.Types;
using GraphQL_API.GraphQL.GraphTypes;
using GraphQL_API.Services;
using GraphQL_API.Services.Interfaces;

namespace GraphQL_API.GraphQL.GraphQueries
{
    public class BooksQuery:ObjectGraphType
    {
        public BooksQuery()
        {
            var booksService = BooksService.GetInstance();
            Field<ListGraphType<GBook>>("Books")
                .Description("Returns a list of books").Resolve(context => booksService.GetAllBooks());

            Field<GBook>("BookById").Description("Gets a single book by id")
             .Argument<NonNullGraphType<IntGraphType>>("isbn", "The ID of the book")
             .Resolve(context => booksService.GetBookByISBN(context.GetArgument<int>("isbn")));
        }
    }
}
