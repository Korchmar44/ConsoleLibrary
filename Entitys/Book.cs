namespace ConsoleLibrary.Entitys
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }


        public List<GenreBook> GenreBooks { get; set; }
        public int AuthorId {  get; set; }
    }
}
