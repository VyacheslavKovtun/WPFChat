using DBLibrary.Models.Entities;
using DBLibrary.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFChatApp.Models.AutoMapper;
using WPFChatApp.ViewModels.Models;

namespace WPFChatApp.ViewModels.View
{
    public class LogInViewModel
    {
        public event Action<string> logInMessage;

        private AutoMapperBase autoMapper;
        private UnitOfWork unitOfWork;

        public LogInViewModel()
        {
            autoMapper = AutoMapperBase.Instance;
            unitOfWork = UnitOfWork.Instance;
        }

        public void CheckSignedUser(string login, string password)
        {
            Task.Run(async () =>
            {
                var users = await unitOfWork.UserRepository.GetAllAsync();
                var user = users.FirstOrDefault(u => u.Login == login);
                if (user != null)
                {
                    if (user.Password == password)
                    {
                        MainWindowViewModel.CurrentUser = autoMapper.Mapper.Map<UserViewModel>(user);
                        logInMessage?.Invoke($"{user.Nickname}, you are welcome!");
                    }
                    else
                    {
                        logInMessage?.Invoke("Wrong login or password!");
                    }
                }
                else
                {
                    logInMessage?.Invoke("User doesn`t exist!");
                }
            });
        }

        public void SignInUser(string nickname, string login, string password)
        {
            Task.Run(async () =>
            {
                var users = await unitOfWork.UserRepository.GetAllAsync();
                var tmp = users.FirstOrDefault(u => u.Login == login);

                if (tmp == null)
                {
                    if (!users.Any(u => u.Nickname == nickname))
                    {
                        User user = new User()
                        {
                            Nickname = nickname,
                            Login = login,
                            Password = password
                        };

                        await unitOfWork.UserRepository.CreateAsync(user);

                        users = await unitOfWork.UserRepository.GetAllAsync();
                        var cUser = users.FirstOrDefault(u => u.Login == user.Login);
                        MainWindowViewModel.CurrentUser = autoMapper.Mapper.Map<UserViewModel>(cUser);
                        logInMessage?.Invoke($"{cUser.Nickname}, you are welcome!");
                    }
                    else
                    {
                        logInMessage?.Invoke("User with such nickname is already existed!");
                    }
                }
                else
                {
                    logInMessage?.Invoke("User is already existed!");
                }
            });
        }
    }
}
