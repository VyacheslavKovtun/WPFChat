using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFChatApp.ViewModels.Models
{
    public class UserContactsViewModel : INotifyPropertyChanged, ICloneable
    {
        public int Id { get; set; }
        private int userId;

        private ICollection<UserViewModel> contacts;

        public int UserId
        {
            get => userId;
            set
            {
                userId = value;
                OnPropertyChanged(nameof(UserId));
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

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public object Clone()
        {
            return new UserContactsViewModel
            {
                Id = this.Id,
                UserId = this.UserId,

                Contacts = this.Contacts
            };
        }
    }
}
