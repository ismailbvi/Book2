namespace BookStore.Models.Request
{
    public class AddBookRequest
    {
        public string Description {get; set;}

        public string Name { get; set;}

        public Guid AuthorId { get; set;}
    }
}
