using GraphQL_API.GraphQL.GraphTypes;

namespace GraphQL_API.GraphQL.GraphQueries.QueryTypes
{
    public class BookQueryType:ObjectType<BooksQuery>
    {
        protected override void Configure(IObjectTypeDescriptor<BooksQuery> descriptor)
        {
            descriptor
                 .Field(f => f.getAllBooks()).Type<GBook>();
        }
    }
}
