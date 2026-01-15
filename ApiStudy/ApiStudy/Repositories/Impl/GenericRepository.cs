using ApiStudy.Model.Base;
using ApiStudy.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace ApiStudy.Repositories.Impl
{
    public class GenericRepository<T> : IRepository<T> where T : BaseEntity
    {
        private MSSQLContext _context;
        private DbSet<T> _dataset;

        public GenericRepository(MSSQLContext context)
        {
            _context = context;
            _dataset = _context.Set<T>();
        }

        public List<T> FindAll()
        {
            return _dataset.ToList();
        }
        public T FindById(long id)
        {
            return _dataset.Find(id);
        }

        public T Create(T item)
        {
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }
        public T Update(T item)
        {
            T selectedItem = _dataset.Find(item.Id);
            if (selectedItem == null) return null;

            _context.Entry(selectedItem).CurrentValues.SetValues(item);
            _context.SaveChanges();

            return item;
        }
        public void Delete(long id)
        {
            T selectedItem = _dataset.Find(id);
            if (selectedItem == null) return;

            _context.Remove(selectedItem);
            _context.SaveChanges();
        }
        public bool Exists(long id)
        {
            return _dataset.Any(e => e.Id == id);
        }
    }
}
