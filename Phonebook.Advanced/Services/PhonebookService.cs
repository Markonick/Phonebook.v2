using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Phonebook.Advanced.Models;
using Newtonsoft.Json;

namespace Phonebook.Advanced.Services
{
    public class PhonebookService : IPhonebookService
    {
        private readonly HttpClient _client;
        private readonly string _baseUrl;

        public PhonebookService(HttpClient client, string baseUrl)
        {
            _client = client;
            _baseUrl = baseUrl;
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<ContactsViewModel> GetContactsAsync()
        {
            var jsonResponse = new ContactsViewModel();

            try
            {
                var response = await _client.GetAsync(_baseUrl);

                if (response.IsSuccessStatusCode)
                {
                    var resp = response.Content.ReadAsStringAsync().Result;

                    jsonResponse = JsonConvert.DeserializeObject<ContactsViewModel>(resp);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return jsonResponse;
        }
    }
}
