using GraphQL_API.Models;
using GraphQL_API.Services.Interfaces;

namespace GraphQL_API.GraphQL.GraphMutations.MutationsTypes
{
    public class ReadBooksMutation: ObjectType<BooksMutation>
    {
        protected override void Configure(
          IObjectTypeDescriptor<BooksMutation> descriptor)
        {
            descriptor.Field(f => f.AddABook(default));
        }
    }
}
