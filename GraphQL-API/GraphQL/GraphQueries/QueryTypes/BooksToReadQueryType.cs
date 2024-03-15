using GraphQL_API.Services.Interfaces;
using GraphQL_API.Services;
using GraphQL_API.Models;
using GraphQL_API.GraphQL.GraphTypes;

namespace GraphQL_API.GraphQL.GraphQueries.QueryTypes
{
    public class BooksToReadQueryType : ObjectTypeExtension<BooksQuery>
    {
        protected override void Configure(IObjectTypeDescriptor<BooksQuery> descriptor)
        {
            descriptor.Name("BooksToRead");
            descriptor
                   .Field("AllBooksToRead").ResolveWith<BooksToReadQuery>(r => r.GetAllToReadBooks()).Type<NonNullType<GBook>>().Description("Returns a list of all books to read");

            descriptor
                .Field(f => "hello world").Type<StringType>();

        }
    }
}
