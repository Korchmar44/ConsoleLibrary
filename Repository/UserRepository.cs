using ConsoleLibrary.Entitys;

namespace ConsoleLibrary.Repository
{
    public class UserRepository : VirtualReository<User>
    {
        ConsoleLibraryContext consoleLibraryContext;

        User User { get; set; }

        public UserRepository(User user)
        {
            User = user;
        }

        public override void Add(User entity)
        {
            using (consoleLibraryContext = new ConsoleLibraryContext())
            {
                consoleLibraryContext.Users.Add(entity);
                consoleLibraryContext.SaveChanges();
            }
        }

        public override void Delete(User entity)
        {
            using (consoleLibraryContext = new ConsoleLibraryContext())
            {
                consoleLibraryContext.Remove(entity);
                consoleLibraryContext.SaveChanges();
            }
        }

        public override User Select(int id)
        {
            using (consoleLibraryContext = new ConsoleLibraryContext())
            {
                var result = consoleLibraryContext.Users.Where(user => user.Id == id).FirstOrDefault();
                return result;
            }
        }

        public override List<User> SelectAll()
        {
            using (consoleLibraryContext = new ConsoleLibraryContext())
            {
                var result = consoleLibraryContext.Users.ToList();
                return result;
            }
        }

        public override void Update(User entity)
        {
            using (consoleLibraryContext = new ConsoleLibraryContext())
            {
                consoleLibraryContext.Update(entity);
                consoleLibraryContext.SaveChanges();
            }
        }

        public override void UpdateById(int id, string name)
        {
            using (consoleLibraryContext = new ConsoleLibraryContext())
            {
                var result = consoleLibraryContext.Users.Where(user => user.Id == id).FirstOrDefault();
                result.Name = name;
                consoleLibraryContext.SaveChanges();
            }
        }
    }
}
