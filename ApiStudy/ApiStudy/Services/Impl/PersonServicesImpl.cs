using ApiStudy.Data.Converter.Impl.V1;
using ApiStudy.Data.DTO.V1;
using ApiStudy.Model;
using ApiStudy.Repositories;

namespace ApiStudy.Services.Impl
{
    public class PersonServicesImpl : IPersonServices
    {
        private IRepository<Person> _repository;
        private  readonly PersonConverter _converter;

        public PersonServicesImpl(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public List<PersonDTO> FindAll()
        {
            return _converter.ParseList(_repository.FindAll());
        }
        public PersonDTO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id));
        }

        public PersonDTO Create(PersonDTO person)
        {
            var entity = _converter.Parse(person);
            entity = _repository.Create(entity);
            return _converter.Parse(entity);
        }
        public PersonDTO Update(PersonDTO person)
        {
            var entity = _converter.Parse(person);
            entity = _repository.Update(entity);
            return _converter.Parse(entity);
        }
        public void Delete(long Id)
        {
            _repository.Delete(Id);
        }
    }
}
