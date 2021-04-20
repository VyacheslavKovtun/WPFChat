using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFChatApp.ViewModels.Models
{
    public class UserViewModel : INotifyPropertyChanged, ICloneable
    {
        public int Id { get; set; }
        private string nickname = string.Empty;
        private string login = string.Empty;
        private string password = string.Empty;

        private ICollection<UserViewModel> contacts;
        private ICollection<int> contactsId;


        public string Nickname
        {
            get => nickname;
            set
            {
                nickname = value;
                OnPropertyChanged(nameof(Nickname));
            }
        }

        public string Login
        {
            get => login;
            set
            {
                login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICollection<UserViewModel> Contacts
        {
            get => contacts;
            set
            {
                contacts = value;
                OnPropertyChanged(nameof(Contacts));
            }
        }

        public ICollection<int> ContactsId
        {
            get => contactsId;
            set
            {
                contactsId = value;
                OnPropertyChanged(nameof(ContactsId));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public object Clone()
        {
            return new UserViewModel
            {
                Id = this.Id,
                Nickname = this.Nickname,
                Login = this.Login,
                Password = this.Password,

                ContactsId = this.ContactsId,
                Contacts = this.Contacts
            };
        }
    }
}
