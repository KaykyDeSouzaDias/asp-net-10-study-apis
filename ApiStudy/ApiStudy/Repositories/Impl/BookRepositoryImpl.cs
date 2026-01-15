using ApiStudy.Model;
using ApiStudy.Model.Context;

namespace ApiStudy.Repositories.Impl
{
    public class BookRepositoryImpl : IBookRepository
    {
        private MSSQLContext _context;

        public BookRepositoryImpl(MSSQLContext context)
        {
            _context = context;
        }

        public List<Book> FindAll()
        {
            return _context.Books.ToList();
        }
        public Book FindById(long id)
        {
            return _context.Books.Find(id);
        }

        public Book Create(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }
        public Book Update(Book book)
        {
            Book selectedBook = _context.Books.Find(book.Id);
            if (selectedBook == null) return null;

            _context.Entry(selectedBook).CurrentValues.SetValues(book);
            _context.SaveChanges();

            return book;
        }
        public void Delete(long id)
        {
            Book selectedBook = _context.Books.Find(id);
            if (selectedBook == null) return;

            _context.Books.Remove(selectedBook);
            _context.SaveChanges();
        }
    }
}
