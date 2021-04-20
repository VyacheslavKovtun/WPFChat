using DBLibrary.Models.Entities;
using DBLibrary.Models.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WPFChatApp.Commands;
using WPFChatApp.Models.AutoMapper;
using WPFChatApp.ViewModels.Models;

namespace WPFChatApp.ViewModels.View
{
    public class ContactsViewModel : INotifyPropertyChanged
    {
        private AutoMapperBase autoMapper;
        private UnitOfWork unitOfWork;

        #region Data

        public UserViewModel CurrentUser { get; set; }
        public ObservableCollection<UserViewModel> Contacts { get; set; } = new ObservableCollection<UserViewModel>();
        public ObservableCollection<UserViewModel> AllUsers { get; set; } = new ObservableCollection<UserViewModel>();

        private UserViewModel selectedContact;
        public UserViewModel SelectedContact
        {
            get => selectedContact;
            set
            {
                selectedContact = value;
                OnPropertyChanged(nameof(SelectedContact));
            }
        }

        private UserViewModel selectedUser;
        public UserViewModel SelectedUser
        {
            get => selectedUser;
            set
            {
                selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }

        #endregion

        #region Commands

        private ActionCommand deleteContactCommand;
        public ActionCommand DeleteContactCommand
        {
            get => deleteContactCommand ?? (deleteContactCommand = new ActionCommand(obj =>
            {
                if (obj != null)
                {
                    UserViewModel contact = obj as UserViewModel;
                    var idx = Contacts.IndexOf(contact);
                    Contacts.Remove(contact);
                    CurrentUser.ContactsId.Remove(contact.Id);
                    AllUsers.Add(contact);

                    var updatedUser = autoMapper.Mapper.Map<User>(CurrentUser);
                    Task.Run(async () =>
                    {
                        await unitOfWork.UserRepository.UpdateAsync(updatedUser);
                    });

                    if (Contacts.Count > 0 && idx != -1)
                    {
                        if (idx == Contacts.Count - 1)
                        {
                            SelectedContact = Contacts.Last();
                        }

                        else if (idx == 0)
                        {
                            SelectedContact = Contacts.First();
                        }
                        else
                        {
                            SelectedContact = Contacts[idx - 1];
                        }
                    }
                }
            }));
        }

        private ActionCommand addNewContactCommand;
        public ActionCommand AddNewContactCommand
        {
            get => addNewContactCommand ?? (addNewContactCommand = new ActionCommand(obj =>
            {
                if (obj != null)
                {
                    AllUsers.Remove(obj as UserViewModel);
                    UserViewModel uservm = obj as UserViewModel;
                    if (!Contacts.Contains(uservm) && uservm != null)
                    {
                        Contacts.Add(uservm);
                        CurrentUser.ContactsId.Add(uservm.Id);
                        var updatedUser = autoMapper.Mapper.Map<User>(CurrentUser);
                        Task.Run(async () =>
                        {
                            await unitOfWork.UserRepository.UpdateAsync(updatedUser);
                        });
                        SelectedContact = uservm;
                    }
                }
            }));
        }
        #endregion

        public ContactsViewModel(UserViewModel currentUser)
        {
            autoMapper = AutoMapperBase.Instance;
            unitOfWork = UnitOfWork.Instance;
            CurrentUser = currentUser;
            if (CurrentUser != null)
                LoadDbData();
        }

        private void LoadDbData()
        {
            var dbAllUsers = unitOfWork.UserRepository.GetAllAsync().Result;
            var tmpAllUsers = autoMapper.Mapper.Map<ObservableCollection<UserViewModel>>(dbAllUsers.Where(u => u.Id != CurrentUser.Id));
            CurrentUser = autoMapper.Mapper.Map<UserViewModel>(dbAllUsers.FirstOrDefault(u => u.Id == CurrentUser.Id));
            foreach (var user in tmpAllUsers)
            {
                if (CurrentUser.Contacts.FirstOrDefault(c => c.Id == user.Id) == null)
                    AllUsers.Add(user);
            }

            var dbContacts = unitOfWork.UserRepository.GetAllAsync().Result;
            var tmpContacts = autoMapper.Mapper.Map<ObservableCollection<UserViewModel>>(dbContacts);
            foreach (var contact in tmpContacts)
            {
                if (CurrentUser.Contacts.FirstOrDefault(c => c.Id == contact.Id) != null)
                    Contacts.Add(contact);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
