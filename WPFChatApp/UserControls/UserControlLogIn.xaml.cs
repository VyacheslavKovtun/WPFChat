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
    public partial class UserControlLogIn : UserControl
    {
        LogInViewModel viewModel;

        public UserControlLogIn()
        {
            InitializeComponent();
            viewModel = new LogInViewModel();
            viewModel.logInMessage += ViewModel_logInMessage;
            DataContext = viewModel;
        }

        private void ViewModel_logInMessage(string msg)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                LoadingIcon.Visibility = Visibility.Hidden;
                MessageBox.Show(msg);
            }));
        }

        private void LogInBtn_Click(object sender, RoutedEventArgs e)
        {
            LoadingIcon.Visibility = Visibility.Visible;
            if (NameTB.Text.Length == 0)
            {
                viewModel.CheckSignedUser(LoginTB.Text, PasswordBox.Password);
            }
            else
                viewModel.SignInUser(NameTB.Text, LoginTB.Text, PasswordBox.Password);
        }
    }
}
