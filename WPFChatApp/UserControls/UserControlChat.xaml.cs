using ChatLibrary.Models;
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
    public partial class UserControlChat : UserControl
    {
        ChatViewModel chatViewModel;

        public UserControlChat()
        {
            InitializeComponent();
            chatViewModel = new ChatViewModel(MainWindowViewModel.CurrentUser);
            chatViewModel.LoadChatMessages += ChatViewModel_LoadChatMessages;
            chatViewModel.LoadGroupMessages += ChatViewModel_LoadGroupMessages;
            chatViewModel.ReceivedMessage += ChatViewModel_ReceivedMessage;
            DataContext = chatViewModel;
        }

        private void ChatViewModel_LoadGroupMessages(IEnumerable<DBLibrary.Models.Entities.GroupMessage> messages)
        {
            foreach (var msg in messages)
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    MainTB.Text += $"{msg.From.Nickname}: {msg.Text}\n";
                }));
            }
        }

        private void ChatViewModel_LoadChatMessages(IEnumerable<DBLibrary.Models.Entities.Message> messages)
        {
            foreach (var msg in messages)
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    MainTB.Text += $"{msg.From.Nickname}: {msg.Text}\n";
                }));
            }
        }

        private void ChatViewModel_ReceivedMessage(Message msg)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                MainTB.Text += $"{msg.User}: {msg.Text}\n";
            }));
        }

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            chatViewModel.SendMsg(MsgTB.Text);
            MsgTB.Clear();
        }
    }
}
