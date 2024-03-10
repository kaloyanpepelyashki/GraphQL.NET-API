using GraphQL.Types;
using GraphQL_API.GraphQL.GraphQueries;

namespace GraphQL_API.GraphQL
{
    public class GraphSchema:Schema 
    {
        public GraphSchema()
        {
            var query = new BooksQuery();
            this.Query = query;
        }
    }
}
