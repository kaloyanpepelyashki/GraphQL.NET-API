using GraphQL.Types;
using GraphQL_API.Models;
using MongoDB.Bson;

namespace GraphQL_API.GraphQL.GraphTypes
{
    public class GBook: ObjectType<Book>
    {
       
         protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
         {
            descriptor
                .Field(f => f.Id).Type<StringType>();

            descriptor
                .Field(f => f.ISBN).Type<StringType>();

            descriptor
                .Field(f => f.Title).Type<StringType>();

            descriptor
                .Field(f => f.Author).Type<StringType>();

            descriptor
                .Field(f => f.Description).Type<StringType>();
         }
   

    }
     
 }

