namespace ConsoleLibrary.Entitys
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PublishYear { get; set; }

        public int GenreBooksId { get; set; }
        public int AuthorId {  get; set; }
        public int UserId { get; set; }

        public GenreBook GenreBooks { get; set; }
        public Author Author { get; set; }
        public User User { get; set; }
    }
}
