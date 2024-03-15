using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GraphQL_API.Models
{
    public class Book
    {
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; init; }

        [BsonElement("ISBN")]
        public string  ISBN { get; init; }

        [BsonElement("bookTitle")]
        public string Title { get; set; }

        [BsonElement("bookDescription")]
        public string Description { get; set; }

        [BsonElement("bookAuthor")]
        public string Author { get; set; }

        public Book (string isbn, string title, string description, string author)
        {
            ISBN = isbn;
            Title = title;
            Description = description;
            Author = author;
        }

 
    }
}
