using ChatLibrary.Models;
using DBLibrary.Models.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WPFChatApp.Models.AutoMapper;
using WPFChatApp.ViewModels.Models;

namespace WPFChatApp.ViewModels.View
{
    public class ChatViewModel : INotifyPropertyChanged
    {
        public event Action<Message> ReceivedMessage;
        public event Action<IEnumerable<DBLibrary.Models.Entities.Message>> LoadChatMessages;
        public event Action<IEnumerable<DBLibrary.Models.Entities.GroupMessage>> LoadGroupMessages;

        private AutoMapperBase autoMapper;
        private UnitOfWork unitOfWork;

        public const string HOST = "192.168.1.2";
        public const int PORT = 55_000;
        static Client client;

        public UserViewModel CurrentUser { get; set; }
        public ObservableCollection<UserViewModel> Chats { get; set; } = new ObservableCollection<UserViewModel>();
        public ObservableCollection<GroupViewModel> Groups { get; set; } = new ObservableCollection<GroupViewModel>();

        private UserViewModel selectedChat;
        public UserViewModel SelectedChat
        {
            get => selectedChat;
            set
            {
                selectedChat = value;
                var dirClient = Server.clients.FirstOrDefault(c => c.User.Nickname == SelectedChat.Nickname);
                if (dirClient != null)
                    Server.DirectedClient = dirClient;
                OpenChat(SelectedChat);
                OnPropertyChanged(nameof(SelectedChat));
            }
        }

        private GroupViewModel selectedGroup;
        public GroupViewModel SelectedGroup
        {
            get => selectedGroup;
            set
            {
                selectedGroup = value;

                foreach (var client in Server.clients)
                {
                    //if (SelectedGroup.Users.FirstOrDefault(u => u.Nickname == client.User.Nickname) != null)
                    //Server.DirectedClients.Add(client);
                }

                OpenGroupChat(SelectedGroup);
                OnPropertyChanged(nameof(SelectedGroup));
            }
        }

        private async void OpenGroupChat(GroupViewModel selectedGroup)
        {
            var dbGroupMessages = await unitOfWork.GroupMessageRepository.GetAllAsync();

            var groupMessages = dbGroupMessages.Where(gm => gm.ToId == selectedGroup.Id);

            LoadGroupMessages?.Invoke(groupMessages);
        }

        private async void OpenChat(UserViewModel selectedChat)
        {
            var dbMessages = await unitOfWork.MessageRepository.GetAllAsync();

            var messages = dbMessages.Where(m =>
            (m.FromId == selectedChat.Id && m.ToId == CurrentUser.Id)
            || (m.FromId == CurrentUser.Id && m.ToId == selectedChat.Id));

            LoadChatMessages?.Invoke(messages);
        }

        public ChatViewModel(UserViewModel currentUser)
        {
            CurrentUser = currentUser;
            autoMapper = AutoMapperBase.Instance;
            unitOfWork = UnitOfWork.Instance;
            if (CurrentUser != null)
            {
                client = new Client(CurrentUser.Nickname, HOST, PORT);
                client.ReceiveMessage += Client_ReceiveMessage;
                LoadDbData();
            }
        }

        private void Client_ReceiveMessage(Message msg)
        {
            var msgVM = autoMapper.Mapper.Map<MessageViewModel>(msg);
        }

        public void SendMsg(string msg)
        {
            client.SendMessage(msg);
        }

        static async void Run()
        {
            await client.Start();
        }

        private void LoadDbData()
        {
            var dbUsers = unitOfWork.UserRepository.GetAllAsync().Result;
            var tmpContacts = autoMapper.Mapper.Map<ObservableCollection<UserViewModel>>(dbUsers);
            foreach (var contact in tmpContacts)
            {
                if (CurrentUser.Contacts.FirstOrDefault(c => c.Id == contact.Id) != null)
                    Chats.Add(contact);
            }

            var dbGroups = unitOfWork.GroupRepository.GetAllAsync().Result;
            var tmpGroups = autoMapper.Mapper.Map<ObservableCollection<GroupViewModel>>(dbGroups);
            foreach (var group in tmpGroups)
            {
                if (group.Users.FirstOrDefault(u => u.Id == CurrentUser.Id) != null)
                    Groups.Add(group);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
