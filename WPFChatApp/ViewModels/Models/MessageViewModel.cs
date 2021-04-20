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
        private UserViewModel from;
        private int fromId;
        private UserViewModel to;
        private int toId;
        private string text;

        public UserViewModel From
        {
            get => from;
            set
            {
                from = value;
                OnPropertyChanged(nameof(From));
            }
        }

        public int FromId
        {
            get => fromId;
            set
            {
                fromId = value;
                OnPropertyChanged(nameof(FromId));
            }
        }

        public UserViewModel To
        {
            get => to;
            set
            {
                to = value;
                OnPropertyChanged(nameof(To));
            }
        }

        public int ToId
        {
            get => toId;
            set
            {
                toId = value;
                OnPropertyChanged(nameof(ToId));
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

                From = this.From,
                FromId = this.FromId,

                To = this.To,
                ToId = this.ToId,

                Text = this.Text
            };
        }
    }
}
