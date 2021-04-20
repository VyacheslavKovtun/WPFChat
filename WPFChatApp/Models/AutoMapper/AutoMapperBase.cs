using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFChatApp.Config;

namespace WPFChatApp.Models.AutoMapper
{
    public class AutoMapperBase
    {
        public IMapper Mapper { get; }
        private static AutoMapperBase instance;
        public static AutoMapperBase Instance
        {
            get => instance ?? (instance = new AutoMapperBase(new AutoMapperProfile()));
        }
        private AutoMapperBase(Profile profile)
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(profile));
            Mapper = config.CreateMapper();
        }
    }
}
