using ApiStudy.Model;

namespace ApiStudy.Services.Impl
{
    public class PersonServicesImpl : IPersonServices
    {
        public List<Person> FindAll()
        {
           List<Person> persons = new List<Person>();
            for (int i = 1; i < 9; i++)
            {
                persons.Add(MockPerson(i));
            }

            return persons;
        }
        public Person FindById(long id)
        {
            var person = MockPerson((int) id);

            return person;
        }


        public Person Create(Person person)
        {
            person.Id = new Random().Next(1, 1000); // Simulate ID assignment
            return person;
        }
        public Person Update(Person person)
        {
            return person;
        }
        public void Delete(long id)
        {
            // simulate delete operation
        }

        private Person MockPerson(int index)
        {
            double formattedIndex = (double)index;
            Person person;
            if (index % 2 == 0)
            {
                person = new Person
                {
                    Id = new Random().Next(1, 1000),
                    FirstName = "Maria " + (index / 2),
                    LastName = "Silva " + (index / 2),
                    Address = "123 Main",
                    Gender = "Female",
                };
            }
            else
            {
                person = new Person
                {
                    Id = new Random().Next(1, 1000),
                    FirstName = "John " + ((formattedIndex / 2) + 0.5),
                    LastName = "Doe " + ((formattedIndex / 2) + 0.5),
                    Address = "123 Main",
                    Gender = "Male",
                };
            }
            return person;
        }
    }
}
