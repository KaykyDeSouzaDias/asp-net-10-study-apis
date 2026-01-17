using ApiStudy.Data.Converter.Impl.V2;
using ApiStudy.Data.DTO.V2;
using ApiStudy.Model;
using FluentAssertions;

namespace ApiStudy.Tests
{
    public class PersonConverterTests
    {
        private readonly PersonConverter _converter;

        public PersonConverterTests()
        {
            _converter = new PersonConverter();
        }

        //PersonDTO to Person parse test
        [Fact]
        public void Parse_ShouldConvertPersonDTOToPerson()
        {
            // Arrange
            var dto = new PersonDTO
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Address = "123 Main St",
                Gender = "Male",
                Birthday = new DateTime(1990, 1, 1)
            };

            var expectedPerson = new Person
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Address = "123 Main St",
                Gender = "Male"
            };

            // Act
            var convertedPerson = _converter.Parse(dto);

            // Assert
            convertedPerson.Should().NotBeNull();

            //convertedPerson.Id.Should().Be(expectedPerson.Id);
            //convertedPerson.FirstName.Should().Be(expectedPerson.FirstName);
            //convertedPerson.LastName.Should().Be(expectedPerson.LastName);
            //convertedPerson.Address.Should().Be(expectedPerson.Address);
            //convertedPerson.Gender.Should().Be(expectedPerson.Gender);

            convertedPerson.Should().BeEquivalentTo(expectedPerson);
        }

        [Fact]
        public void Parse_ShouldReturnNull_WhenPersonDTOIsNull()
        {
            // Arrange
            PersonDTO dto = null;
            // Act
            var convertedPerson = _converter.Parse(dto);
            // Assert
            convertedPerson.Should().BeNull();
        }

        //Person to PersonDTO parse test
        [Fact]
        public void Parse_ShouldConvertPersonToPersonDTO()
        {
            // Arrange
            var person = new Person
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Address = "123 Main St",
                Gender = "Male"
            };

            var expectedDTO = new PersonDTO
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Address = "123 Main St",
                Gender = "Male"
            };

            // Act
            var convertedPerson = _converter.Parse(person);

            // Assert
            convertedPerson.Should().NotBeNull();

            //convertedPerson.Id.Should().Be(expectedPerson.Id);
            //convertedPerson.FirstName.Should().Be(expectedPerson.FirstName);
            //convertedPerson.LastName.Should().Be(expectedPerson.LastName);
            //convertedPerson.Address.Should().Be(expectedPerson.Address);
            //convertedPerson.Gender.Should().Be(expectedPerson.Gender);

            convertedPerson.Should().BeEquivalentTo(expectedDTO,
                options => options.Excluding(person => person.Birthday));
            convertedPerson.Birthday.Should().NotBeNull();
        }

        [Fact]
        public void Parse_ShouldReturnNull_WhenPersonIsNull()
        {
            // Arrange
            Person person = null;
            // Act
            var convertedPerson = _converter.Parse(person);
            // Assert
            convertedPerson.Should().BeNull();
        }

        [Fact]
        public void ParseList_ShouldConvertPersonDTOListToPersonList()
        {
            // Arrange
            var dtoList = new List<PersonDTO>
            {
                new PersonDTO
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Address = "123 Main St",
                    Gender = "Male",
                    Birthday = new DateTime(1990, 1, 1)
                },
                new PersonDTO
                {
                    Id = 2,
                    FirstName = "Mario",
                    LastName = "Liu",
                    Address = "Ohio",
                    Gender = "Male",
                    Birthday = new DateTime(1985, 5, 15)
                }
            };

            var expectedPersonList = new List<Person>
            {
               new Person
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Address = "123 Main St",
                    Gender = "Male",
                    //Birthday = new DateTime(1990, 1, 1)
                },
                new Person
                {
                    Id = 2,
                    FirstName = "Mario",
                    LastName = "Liu",
                    Address = "Ohio",
                    Gender = "Male",
                    //Birthday = new DateTime(1985, 5, 15)
                }
            };

            // Act
            var convertedPersonList = _converter.ParseList(dtoList);

            // Assert
            convertedPersonList.Should().NotBeNull();
            convertedPersonList.Should().HaveCount(2);

            convertedPersonList[0].Should().BeEquivalentTo(expectedPersonList[0]);
            convertedPersonList[1].Should().BeEquivalentTo(expectedPersonList[1]);
            
            convertedPersonList.Should().BeEquivalentTo(expectedPersonList);
        }

        [Fact]
        public void Parse_ShouldReturnNull_WhenPersonDTOListIsNull()
        {
            // Arrange
            List<PersonDTO> personList = null;
            // Act
            var convertedPersonList = _converter.ParseList(personList);
            // Assert
            convertedPersonList.Should().BeNull();
        }

        [Fact]
        public void ParseList_ShouldConvertPersonListToPersonDTOList()
        {
            // Arrange
            var personList = new List<Person>
            {
                new Person
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Address = "123 Main St",
                    Gender = "Male",
                },
                new Person
                {
                    Id = 2,
                    FirstName = "Mario",
                    LastName = "Liu",
                    Address = "Ohio",
                    Gender = "Male",
                }
            };

            var expectedPersonDTOList = new List<PersonDTO>
            {
               new PersonDTO
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    Address = "123 Main St",
                    Gender = "Male",
                    Birthday = new DateTime(1990, 1, 1)
                },
                new PersonDTO
                {
                    Id = 2,
                    FirstName = "Mario",
                    LastName = "Liu",
                    Address = "Ohio",
                    Gender = "Male",
                    Birthday = new DateTime(1985, 5, 15)
                }
            };

            // Act
            var convertedPersonList = _converter.ParseList(personList);

            // Assert
            convertedPersonList.Should().NotBeNull();
            convertedPersonList.Should().HaveCount(2);

            convertedPersonList[0].Should().BeEquivalentTo(expectedPersonDTOList[0],
                options => options.Excluding(person => person.Birthday));
            convertedPersonList[1].Should().BeEquivalentTo(expectedPersonDTOList[1],
                options => options.Excluding(person => person.Birthday));

            convertedPersonList.Should().BeEquivalentTo(expectedPersonDTOList,
                options => options.Excluding(person => person.Birthday));
        }

        [Fact]
        public void Parse_ShouldReturnNull_WhenPersonListIsNull()
        {
            // Arrange
            List<Person> personList = null;
            // Act
            var convertedPersonList = _converter.ParseList(personList);
            // Assert
            convertedPersonList.Should().BeNull();
        }
    }
}
