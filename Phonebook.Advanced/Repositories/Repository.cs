using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Phonebook.Advanced.Models;
using Phonebook.Advanced.Services;

namespace Phonebook.Advanced.Repositories
{
    public class Repository : IRepository
    {
        private readonly ContactsViewModel _list;

        public Repository()
        {
            _list = new ContactsViewModel
            {
                Contacts = new List<ContactViewModel>()
            };
        }

        public async Task SaveContactsAsync(ContactsViewModel contacts)
        {
            await Task.Run(() =>
            {
                foreach (var contact in contacts.Contacts)
                {
                    _list.Contacts.Add(contact);
                }
            });
        }

        public async Task<ContactsViewModel> DeleteAsync(ContactViewModel contact)
        {
            await Task.Run(() =>
            {
                _list.Contacts.Remove(contact);
            });

            return _list;
        }
    }
}
