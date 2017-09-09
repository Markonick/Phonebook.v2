using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Phonebook.Advanced.Models;
using Phonebook.Advanced.Services;

namespace Phonebook.Advanced.Controllers
{
    public class PhonebookController : Controller
    {
        private readonly IPhonebookService _service;

        public PhonebookController(IPhonebookService service)
        {
            _service = service;
        }
        
        public async Task<ViewResult> Contacts(string sortOrder, string searchString)
        {
            var response = await _service.GetContactsAsync();
            var contacts = response.Contacts;

            contacts = SortOrFilterContacts(ViewBag, sortOrder, searchString, contacts);

            return View(contacts);
        }

        public async Task<ViewResult> CreateContact(string sortOrder, string searchString)
        {
            var response = await _service.CreateContactAsync();
            var contacts = response.Contacts;

            contacts = SortOrFilterContacts(ViewBag, sortOrder, searchString, contacts);

            return View(contacts);
        }

        private static List<ContactViewModel> SortOrFilterContacts(dynamic viewBag, string sortOrder, string searchString, List<ContactViewModel> contacts)
        {
            viewBag.NameSortParm = string.IsNullOrEmpty(sortOrder) ? "name_desc" : ""; ;
            viewBag.PhoneSortParm = sortOrder == "phone" ? "phone_desc" : "phone";
            viewBag.AddressSortParm = sortOrder == "address" ? "address_desc" : "address";


            if (!string.IsNullOrEmpty(searchString))
            {
                contacts = contacts.Where(s => s.Name.ToLower().Contains(searchString.ToLower())).ToList();
            }

            switch (sortOrder)
            {
                case "name_desc":
                    contacts = contacts.OrderByDescending(s => s.Name.Split(' ')[1]).ToList();
                    break;
                case "address":
                    contacts = contacts.OrderBy(s => s.Address).ToList();
                    break;
                case "address_desc":
                    contacts = contacts.OrderByDescending(s => s.Address).ToList();
                    break;
                case "phone":
                    contacts = contacts.OrderBy(s => s.PhoneNumber).ToList();
                    break;
                case "phone_desc":
                    contacts = contacts.OrderByDescending(s => s.PhoneNumber).ToList();
                    break;
                default:
                    contacts = contacts.OrderBy(s => s.Name.Split(' ')[1]).ToList();
                    break;
            }

            return contacts;
        }
    }
}
