using GraphQL_API.GraphQL.GraphTypes;

namespace GraphQL_API.GraphQL.GraphQueries.QueryTypes
{
    public class BookQueryType:ObjectType<BooksQuery>
    {
        protected override void Configure(IObjectTypeDescriptor<BooksQuery> descriptor)
        {
            descriptor
                 .Field(f => f.GetAllBooks()).Type<ListType<GBook>>();

            descriptor
                .Field(f => f.GetBookByTite(default!)).Type<GBook>().Argument("title", arg => arg.Type<NonNullType<StringType>>()).Description("Returns a book based on its title");

            descriptor
              .Field(f => f.GetBookByISBN(default!)).Type<GBook>().Argument("isbn", arg => arg.Type<NonNullType<StringType>>()).Description("Returns a book based on its ISBN");
        }
    }
}
