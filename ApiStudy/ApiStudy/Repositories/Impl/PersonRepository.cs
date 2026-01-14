using ApiStudy.Model;
using ApiStudy.Model.Context;

namespace ApiStudy.Repositories.Impl
{
    public class PersonRepository : IPersonRepository
    {
        private MSSQLContext _context;

        public PersonRepository(MSSQLContext context)
        {
            _context = context;
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }
        public Person FindById(long id)
        {
            return _context.Persons.Find(id);
        }


        public Person Create(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();

            return person;
        }
        public Person Update(Person person)
        {
            Person selectedPerson = _context.Persons.Find(person.Id);
            if (selectedPerson == null) return null;

            _context.Entry(selectedPerson).CurrentValues.SetValues(person);
            _context.SaveChanges();

            return person;
        }
        public void Delete(long Id)
        {
            Person selectedPerson = _context.Persons.Find(Id);
            if (selectedPerson == null) return;

            _context.Remove(selectedPerson);
            _context.SaveChanges();
        }
    }
}
