using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFChatApp.ViewModels.View;

namespace WPFChatApp.UserControls
{
    public partial class UserControlContacts : UserControl
    {
        ContactsViewModel contactsViewModel = new ContactsViewModel(MainWindowViewModel.CurrentUser);

        public UserControlContacts()
        {
            InitializeComponent();
            DataContext = contactsViewModel;
        }

        private void WriteToContact_Click(object sender, RoutedEventArgs e)
        {
            //Open or create chat with contact
            //selected contact
        }
    }
}
