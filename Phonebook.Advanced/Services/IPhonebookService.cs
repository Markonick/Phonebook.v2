using System.Threading.Tasks;
using Phonebook.Advanced.Models;

namespace Phonebook.Advanced.Services
{
    public interface IPhonebookService
    {
        Task<ContactsViewModel> GetContactsAsync();
        Task<ContactsViewModel> CreateContactAsync(ContactViewModel contact);
        Task<ContactsViewModel> DeleteContactAsync(ContactViewModel contact);
    }
}