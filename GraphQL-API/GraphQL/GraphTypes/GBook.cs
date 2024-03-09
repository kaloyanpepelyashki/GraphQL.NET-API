using GraphQL.Types;
using GraphQL_API.Models;

namespace GraphQL_API.GraphQL.GraphTypes
{
    public class GBook:ObjectGraphType<Book>
    {
        public GBook()
        {
            Field(x => x.Id, type: typeof(IdGraphType)).Description("The Id of a book");
            Field(x => x.ISBN, type: typeof(IntGraphType)).Description("The ISBN of a book");
            Field(x => x.Title, type: typeof(StringGraphType)).Description("The Title of a book");
            Field(x => x.Description, type: typeof(StringGraphType)).Description("The Description of a book");
            Field(x => x.Author, type: typeof(StringGraphType)).Description("The Author of a book");

        }
     
    }
}
