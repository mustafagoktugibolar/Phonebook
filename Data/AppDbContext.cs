using Microsoft.EntityFrameworkCore;
using Phonebook.Models;




namespace Phonebook.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\mustafagoktugibolar\\source\\repos\\Phonebook\\contacts.db");
        }
    }
}
