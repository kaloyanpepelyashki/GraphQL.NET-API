namespace GraphQL_API.Models
{
    public class Book
    {
        public int Id { get; init; }
        public int  ISBN { get; init; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public Book (string title, string description, string author)
        {
            Title = title;
            Description = description;
            Author = author;
        }

 
    }
}
