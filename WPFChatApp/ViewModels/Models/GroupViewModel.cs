using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFChatApp.ViewModels.Models
{
    public class GroupViewModel : INotifyPropertyChanged, ICloneable
    {
        public int Id { get; set; }
        private string name = string.Empty;
        private ICollection<UserViewModel> users;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public ICollection<UserViewModel> Users
        {
            get => users;
            set
            {
                users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public object Clone()
        {
            return new GroupViewModel
            {
                Id = this.Id,
                Name = this.Name,
                Users = this.Users
            };
        }
    }
}
