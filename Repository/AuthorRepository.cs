using ConsoleLibrary.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLibrary.Repository
{
    public class AuthorRepository : VirtualReository<Author>
    {
        Author Author { get; set; }

        public AuthorRepository(Author author)
        {
            Author = author;
        }

        public override void Add(Author entity)
        {
            using (var db = new ConsoleLibraryContext())
            {
                db.Authors.Add(entity);
                db.SaveChanges();
            }
        }

        public override void Delete(Author entity)
        {
            using (var db = new ConsoleLibraryContext())
            {
                db.Authors.Remove(entity);
                db.SaveChanges();
            }
        }

        public override Author Select(int id)
        {
            using (var db = new ConsoleLibraryContext())
            {
                var result = db.Authors.Where(author => author.Id == id).FirstOrDefault();
                return result;
            }
        }

        public override List<Author> SelectAll()
        {
            using (var db = new ConsoleLibraryContext())
            {
                var result = db.Authors.ToList();
                return result;
            }
        }

        public override void Update(Author entity)
        {
            using (var db = new ConsoleLibraryContext())
            {
                db.Authors.Update(entity);
                db.SaveChanges();
            }
        }

        public override void UpdateById(int id, List<string> prop)
        {
            using (var db = new ConsoleLibraryContext())
            {
                var result = db.Authors.Where(author => author.Id == id).FirstOrDefault();
                List<GenreBook> genre = null;
                if (prop != null)
                {
                    foreach (var item in prop)
                    {
                        var res = db.GenreBooks.Where(g => g.Name == item).FirstOrDefault();
                        genre.Add(res);
                    }
                }
                result.GenreBooks = genre;
            }
        }
    }
}
