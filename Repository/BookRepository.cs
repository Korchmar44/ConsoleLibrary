using ConsoleLibrary.Entitys;

namespace ConsoleLibrary.Repository
{
    public class BookRepository: VirtualReository<Book>
    {
        public Book Book {  get; set; }
        public BookRepository(Book book) 
        { 
            Book = book;        
        }

        public override List<Book> SelectAll()
        {
            using (var db = new ConsoleLibraryContext())
            {
                var result = db.Books.ToList();
                return result;
            }
        }

        public override Book Select(int id)
        {
            using (var db = new ConsoleLibraryContext())
            {
                var result = db.Books.Where(book => book.Id == id).FirstOrDefault();
                return result;
            }
        }

        public override void Add(Book entity)
        {
            using (var db = new ConsoleLibraryContext())
            {
                db.Books.Add(entity);
                db.SaveChanges();
            }
        }

        public override void Update(Book entity)
        {
            using (var db = new ConsoleLibraryContext())
            {
                db.Books.Update(entity);
                db.SaveChanges();
            }
        }

        public override void Delete(Book entity)
        {
            using (var db = new ConsoleLibraryContext())
            {
                db.Remove(entity);
                db.SaveChanges();
            }
        }

        public override void UpdateById(int id, int newYear)
        {
            using (var db = new ConsoleLibraryContext())
            {
                var result = db.Books.Where(book => book.Id == id).FirstOrDefault();
                result.PublishYear = newYear;
                db.SaveChanges();
            }
        }

        //Получать список книг определенного жанра и вышедших между определенными годами.
        public List<Book> SelectBookByGenre(GenreBook genre, int beginYear, int lastYear)
        {
            using (var db = new ConsoleLibraryContext())
            {
                var result = db.Books.Join(db.GenreBooks, b => b.GenreBooksId, g => g.Id, (b, g) => Book ).Where(b=>b.GenreBooks == genre && b.PublishYear >= beginYear && b.PublishYear <= lastYear).ToList();
                return result;
            }                
        }

        //Получать количество книг определенного автора в библиотеке.
        public int CountBookByAuthor(Author author)
        {
            using (var db = new ConsoleLibraryContext())
            {
                var result = db.Books.Where(b=>b.AuthorId == author.Id).Count();
                return result;
            }

        }

        //Получать количество книг определенного жанра в библиотеке.
        public int CountBookByGenreBook(GenreBook genre)
        {
            using (var db = new ConsoleLibraryContext())
            {
                var result = db.Books.Where(b => b.GenreBooksId == genre.Id).Count();
                return result;
            }

        }

        //Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.
        public bool AvailabilityBookByAuthorBookName(Author author, Book book)
        {
            using (var db = new ConsoleLibraryContext())
            {
                var result = db.Books.Where(b => b.Name == book.Name && b.AuthorId == author.Id).Any();
                return result;
            }
        }

        //Получать булевый флаг о том, есть ли определенная книга на руках у пользователя.
        public bool AvailabilityBookByUser(Book book, User user)
        {
            using (var db = new ConsoleLibraryContext())
            {
                var result = db.Users.Where(u => u.Id == user.Id && u.Books.Any(b=>b.Id ==book.Id)).Any();
                return result;
            }
        }

        //Получать количество книг на руках у пользователя.
        public int CountBookByUser(User user)
        {
            using (var db = new ConsoleLibraryContext())
            {
                var result = db.Books.Where(b=>b.UserId == user.Id).Count();
                return result;
            }
        }

        //Получение последней вышедшей книги.
        public Book TakeLastBook()
        {
            using (var db = new ConsoleLibraryContext())
            {
                var result = db.Books.OrderByDescending(b => b.PublishYear).FirstOrDefault();
                return result;
            }
        }

        //Получение списка всех книг, отсортированного в алфавитном порядке по названию.
        public List<Book> GetListBookByName()
        {
            using (var db = new ConsoleLibraryContext())
            {
                var result = db.Books.OrderBy(b => b.Name).ToList();
                return result;
            }
        }

        //Получение списка всех книг, отсортированного в порядке убывания года их выхода.
        public List<Book>GetListBookByYearDesc()
        {
            using (var db = new ConsoleLibraryContext())
            {
                var result = db.Books.OrderByDescending(b=>b.PublishYear).ToList();
                return result;
            }
        }
    }
}
