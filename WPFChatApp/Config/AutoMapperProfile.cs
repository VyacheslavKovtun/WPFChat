using AutoMapper;
using DBLibrary.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFChatApp.ViewModels.Models;

namespace WPFChatApp.Config
{
    class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserViewModel, User>();
            CreateMap<User, UserViewModel>();

            CreateMap<MessageViewModel, Message>();
            CreateMap<Message, MessageViewModel>();

            CreateMap<Group, GroupViewModel>();
            CreateMap<GroupViewModel, Group>();

            CreateMap<GroupMessage, GroupMessageViewModel>();
            CreateMap<GroupMessageViewModel, GroupMessage>();
        }
    }
}
