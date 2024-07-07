
using System.ComponentModel;
using Phonebook.Models;


namespace Phonebook.ModelViews
{
    public class ContactViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        ContactService _contactService;

        public ContactViewModel()
        {
            _contactService = new ContactService(); 
            LoadData();
        }
        public string AvailableContactsText => 
            ContactsList == null ? "No contacts available" : $"{ContactsList.Count} contacts available";

        private List<Contact> contactsList;
        public List<Contact> ContactsList
        {
            get { return contactsList; }
            set
            {
                contactsList = value;
                OnPropertyChanged(nameof(ContactsList));
                OnPropertyChanged(nameof(AvailableContactsText));
                
            }
        }

        private async void LoadData()
        {
            ContactsList = await _contactService.GetAllContacts();
        }
    }
}
