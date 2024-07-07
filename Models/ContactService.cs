

using Microsoft.EntityFrameworkCore;
using Phonebook.Data;

namespace Phonebook.Models
{
    public class ContactService
    {
        private static List<Contact> ContactsList;
        private readonly AppDbContext _context;

        public ContactService()
        {
            _context = new AppDbContext();
            ContactsList = GetAllContacts().Result;
        }

        public Task<List<Contact>> GetAllContacts()
        {
            return _context.Contacts.ToListAsync();
        }

        public async Task<Contact> GetContactById(int id)
        {
            return await _context.Contacts.FindAsync(id);
        }

        public async Task AddContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateContact(Contact contact)
        {
            _context.Entry(contact).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContact(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
        }
    }
}
