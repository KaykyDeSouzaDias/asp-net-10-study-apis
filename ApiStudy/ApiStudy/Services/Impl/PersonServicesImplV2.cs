using ApiStudy.Data.Converter.Impl.V2;
using ApiStudy.Data.DTO.V2;
using ApiStudy.Model;
using ApiStudy.Repositories;

namespace ApiStudy.Services.Impl
{
    public class PersonServicesImplV2
    {
        private IRepository<Person> _repository;
        private  readonly PersonConverter _converter;

        public PersonServicesImplV2(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        public PersonDTO Create(PersonDTO person)
        {
            var entity = _converter.Parse(person);
            entity = _repository.Create(entity);
            return _converter.Parse(entity);
        }
    }
}
