using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBUS.ViewModel.Email;
using TestBUS.ViewModel.EmailHistory;
using TestBUS.ViewModel.User;
using TestDAL.Entities;

namespace TestBUS.Mapper
{
    public class MaperProfile : Profile
    {
        public MaperProfile()
        {
            CreateMap<User, UserVM>().ReverseMap();
            CreateMap<User, UserCreateVM>().ReverseMap();
            CreateMap<User, UserUpdateVM>().ReverseMap();
            CreateMap<Email, EmailVM>().ReverseMap();
            CreateMap<EmailCreateVM, Email>().ReverseMap();
            CreateMap<EmailUpdateVM, Email>().ReverseMap();
            CreateMap<EmailHistory, EmailHistoryVM>().ReverseMap();
            CreateMap<EmailHistoryCreateVM, EmailHistory>().ReverseMap();
            CreateMap<EmailHistoryUpdateVM, EmailHistory>().ReverseMap();
        }
    }
}
