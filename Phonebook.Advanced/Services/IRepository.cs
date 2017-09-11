using System.Threading.Tasks;
using Phonebook.Advanced.Models;

namespace Phonebook.Advanced.Services
{
    public interface IRepository
    {
        Task SaveContactsAsync(ContactsViewModel contacts);
        Task<ContactsViewModel> DeleteAsync(ContactViewModel contact);
    }
}