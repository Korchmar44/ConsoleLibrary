using ConsoleLibrary.Entitys;

namespace ConsoleLibrary.Repository
{
    public abstract class VirtualReository<T>
    {
        public abstract List<T> SelectAll();

        public abstract T Select(int id);

        public abstract void Add(T entity);

        public abstract void Update(T entity);

        public abstract void Delete(T entity);

        public virtual void UpdateById(int id, int prop) { }

        public virtual void UpdateById(int id, string prop) { }

        public virtual void UpdateById(int id, List<string> prop) { }
    }
}
