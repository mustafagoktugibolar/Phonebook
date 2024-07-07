using System.Text;
using System.Windows;
using System.Windows.Controls;

using Phonebook.ModelViews;

namespace Phonebook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ContactViewModel _contactViewModel;
        public MainWindow()
        {
            InitializeComponent();
            _contactViewModel = new ContactViewModel();
            this.DataContext = _contactViewModel;
        }
    }
}