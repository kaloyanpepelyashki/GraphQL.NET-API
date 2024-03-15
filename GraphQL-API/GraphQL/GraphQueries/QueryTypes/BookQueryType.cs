using GraphQL_API.GraphQL.GraphTypes;

namespace GraphQL_API.GraphQL.GraphQueries.QueryTypes
{
    public class BookQueryType : ObjectType<BooksQuery>
    {
        protected override void Configure(IObjectTypeDescriptor<BooksQuery> descriptor)
        {
            descriptor.Name("AllBooks");
            descriptor
            .Field("GetAllReadBooks").ResolveWith<BooksQuery>(f => f.GetAllBooks()).Type<ListType<GBook>>().Description("Returns a list of books");

            descriptor
            .Field("GetBookByTitle").ResolveWith<BooksQuery>(f => f.GetBookByTite(default!)).Type<GBook>().Argument("title", arg => arg.Type<NonNullType<StringType>>()).Description("Returns a book based on its title");

            descriptor
            .Field("GetBookByISBN").ResolveWith<BooksQuery>(f => f.GetBookByISBN(default!)).Type<GBook>().Argument("isbn", arg => arg.Type<NonNullType<StringType>>()).Description("Returns a book based on its ISBN");
        }
    }
}
