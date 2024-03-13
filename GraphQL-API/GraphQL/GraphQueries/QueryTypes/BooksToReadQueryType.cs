using GraphQL_API.Services.Interfaces;
using GraphQL_API.Services;
using GraphQL_API.Models;
using GraphQL_API.GraphQL.GraphTypes;

namespace GraphQL_API.GraphQL.GraphQueries.QueryTypes
{
    public class BooksToReadQueryType: ObjectTypeExtension<BooksToReadQuery>
    {
        protected override void Configure(IObjectTypeDescriptor<BooksToReadQuery> descriptor)
        {
            descriptor
                   .Field(f => f.GetAllToReadBooks()).Type<ListType<GBook>>();

            descriptor
                .Field(f => "hello world").Type<StringType>();

        }
    }
}
