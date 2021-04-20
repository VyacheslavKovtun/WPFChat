using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WPFChatApp.ViewModels.Models;

namespace WPFChatApp.ViewModels.View
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        MainWindow mainWindow;
        private ListViewItem selectedMainMenuItem;
        public static UserViewModel CurrentUser { get; set; }

        public ListViewItem SelectedMainMenuItem
        {
            get => selectedMainMenuItem;
            set
            {
                selectedMainMenuItem = value;
                OnPropertyChanged(nameof(SelectedMainMenuItem));
                SwitchScreen(selectedMainMenuItem.Tag);
            }
        }

        public void SwitchScreen(object name)
        {
            switch ((string)name)
            {
                case "LogIn":
                    mainWindow.LogInGrid.Visibility = Visibility.Visible;
                    mainWindow.ChatGrid.Visibility = Visibility.Hidden;
                    mainWindow.ContactsGrid.Visibility = Visibility.Hidden;
                    mainWindow.SettingsGrid.Visibility = Visibility.Hidden;
                    break;
                case "Chat":
                    if (CurrentUser != null)
                    {
                        LoadChat();
                        mainWindow.LogInGrid.Visibility = Visibility.Hidden;
                        mainWindow.ChatGrid.Visibility = Visibility.Visible;
                        mainWindow.ContactsGrid.Visibility = Visibility.Hidden;
                        mainWindow.SettingsGrid.Visibility = Visibility.Hidden;
                    }
                    break;
                case "Contacts":
                    if (CurrentUser != null)
                    {
                        LoadContacts();
                        mainWindow.LogInGrid.Visibility = Visibility.Hidden;
                        mainWindow.ChatGrid.Visibility = Visibility.Hidden;
                        mainWindow.ContactsGrid.Visibility = Visibility.Visible;
                        mainWindow.SettingsGrid.Visibility = Visibility.Hidden;
                    }
                    break;
                case "Settings":
                    if (CurrentUser != null)
                    {
                        LoadSettings();
                        mainWindow.LogInGrid.Visibility = Visibility.Hidden;
                        mainWindow.ChatGrid.Visibility = Visibility.Hidden;
                        mainWindow.ContactsGrid.Visibility = Visibility.Hidden;
                        mainWindow.SettingsGrid.Visibility = Visibility.Visible;
                    }
                    break;
            }
        }

        private void LoadSettings()
        {

        }

        private void LoadContacts()
        {
            mainWindow.ContactsUC.DataContext = new ContactsViewModel(CurrentUser);
        }

        private void LoadChat()
        {
            mainWindow.ChatUC.DataContext = new ChatViewModel(CurrentUser);
        }

        public MainWindowViewModel(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
        }

        public MainWindowViewModel() { }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
