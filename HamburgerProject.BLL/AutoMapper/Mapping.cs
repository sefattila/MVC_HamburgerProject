using AutoMapper;
using HamburgerProject.BLL.DTOs.MenuDTOs;
using HamburgerProject.BLL.DTOs.OrderDTOs;
using HamburgerProject.BLL.DTOs.SauceDTOs;
using HamburgerProject.BLL.DTOs.UserDTOs;
using HamburgerProject.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.BLL.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Sauce, SauceCreateDTO>().ReverseMap();
            CreateMap<Sauce, SauceUpdateDTO>().ReverseMap();
            CreateMap<Sauce, SauceDTO>().ReverseMap();

            CreateMap<Order, OrderDTO>().ReverseMap();
            CreateMap<Order, OrderCreateDTO>().ReverseMap();
            CreateMap<Order, OrderUpdateDTO>().ReverseMap();

            CreateMap<Menu, MenuDTO>().ReverseMap();
            CreateMap<Menu, MenuCreateDTO>().ReverseMap();
            CreateMap<Menu, MenuUpdateDTO>().ReverseMap();

            CreateMap<AppUser, UserDTO>().ReverseMap();
            CreateMap<AppUser, UserRegisterDTO>().ReverseMap();
            CreateMap<AppUser, UserUpdateDTO>().ReverseMap();
            CreateMap<AppUser, UserLoginDTO>().ReverseMap();
        }
    }
}
