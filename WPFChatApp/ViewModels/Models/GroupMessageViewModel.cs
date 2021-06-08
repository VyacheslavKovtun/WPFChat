using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFChatApp.ViewModels.Models
{
    public class GroupMessageViewModel : INotifyPropertyChanged, ICloneable
    {
        public int Id { get; set; }
        private int userFromId;
        private int groupToId;
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

        public int GroupToId
        {
            get => groupToId;
            set
            {
                groupToId = value;
                OnPropertyChanged(nameof(GroupToId));
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
            return new GroupMessageViewModel
            {
                Id = this.Id,
                UserFromId = this.UserFromId,
                GroupToId = this.GroupToId,
                Text = this.Text
            };
        }
    }
}
