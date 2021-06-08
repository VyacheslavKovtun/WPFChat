using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFChatApp.ViewModels.Models
{
    public class MessageViewModel : INotifyPropertyChanged, ICloneable
    {
        public int Id { get; set; }
        private int userFromId;
        private int userToId;
        private string text;

        public int UserFromId
        {
            get => userFromId;
            set
            {
                userFromId = value;
                OnPropertyChanged(nameof(UserFromId));
            }
        }

        public int UserToId
        {
            get => userToId;
            set
            {
                userToId = value;
                OnPropertyChanged(nameof(UserToId));
            }
        }

        public string Text
        {
            get => text;
            set
            {
                text = value;
                OnPropertyChanged(nameof(Text));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public object Clone()
        {
            return new MessageViewModel
            {
                Id = this.Id,

                UserFromId = this.UserFromId,

                UserToId = this.UserToId,

                Text = this.Text
            };
        }
    }
}
