using Newtonsoft.Json;

namespace Phonebook.Advanced.Models
{
    public class ContactViewModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
    }
}