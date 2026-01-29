using ApiStudy.JsonSerializers;
using System.Text.Json.Serialization;

namespace ApiStudy.Data.DTO.V2
{
    public class PersonDTO
    {
        //[JsonPropertyOrder(3)]
        //[JsonPropertyName("code")]
        public long Id { get; set; }

        //[JsonPropertyOrder(4)]
        //[JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        //[JsonPropertyOrder(5)]
        //[JsonPropertyName("last_name")]
        public string LastName { get; set; }

        //[JsonPropertyOrder(1)]
        public string Address { get; set; }

        //[JsonPropertyOrder(6)]
        public string Gender { get; set; }

        //[JsonPropertyOrder(2)]
        [JsonConverter(typeof(DateSerializer))]
        public DateTime? Birthday { get; set; }
    }
}
