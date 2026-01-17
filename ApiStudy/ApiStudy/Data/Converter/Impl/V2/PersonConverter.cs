using ApiStudy.Data.Converter.Contract;
using ApiStudy.Data.DTO.V2;
using ApiStudy.Model;

namespace ApiStudy.Data.Converter.Impl.V2
{
    public class PersonConverter : IParser<PersonDTO, Person>, IParser<Person, PersonDTO>
    {
        public PersonDTO Parse(Person origin)
        {
            if (origin == null) return null;
            return new PersonDTO
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender,
                Birthday = DateTime.Now
                //Birthday = origin.Birthday
            };
        }

        public Person Parse(PersonDTO origin)
        {
            if (origin == null) return null;
            return new Person
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender,
                //Birthday = origin.Birthday
            };
        }

        public List<PersonDTO> ParseList(List<Person> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public List<Person> ParseList(List<PersonDTO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
