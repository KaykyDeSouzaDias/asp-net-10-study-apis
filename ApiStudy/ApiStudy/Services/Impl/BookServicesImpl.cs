using ApiStudy.Data.DTO.V1;
using ApiStudy.Model;
using ApiStudy.Repositories;
using Mapster;

namespace ApiStudy.Services.Impl
{
    public class BookServicesImpl : IBookServices
    {
        private IRepository<Book> _repository;

        public BookServicesImpl(IRepository<Book> repository)
        {
            _repository = repository;
        }

        public List<BookDTO> FindAll()
        {
            return _repository.FindAll().Adapt<List<BookDTO>>();
        }
        public BookDTO FindById(long id)
        {
            return _repository.FindById(id).Adapt<BookDTO>();
        }

        public BookDTO Create(BookDTO book)
        {
            var entity = book.Adapt<Book>();
            entity = _repository.Create(entity);
            return entity.Adapt<BookDTO>();
        }
        public BookDTO Update(BookDTO book)
        {
            var entity = book.Adapt<Book>();
            entity = _repository.Update(entity);
            return entity.Adapt<BookDTO>();
        }
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
