using AutoMapper;
using HamburgerProject.BLL.DTOs.MenuDTOs;
using HamburgerProject.BLL.DTOs.OrderDTOs;
using HamburgerProject.BLL.DTOs.SauceDTOs;
using HamburgerProject.BLL.DTOs.UserDTOs;
using HamburgerProject.CORE.Entities;
using HampurgerProjectMVC.UI.Models.VMs.MenuVMs;
using HampurgerProjectMVC.UI.Models.VMs.OrderVMs;
using HampurgerProjectMVC.UI.Models.VMs.SauceVMs;
using HampurgerProjectMVC.UI.Models.VMs.UserVMs;

namespace HampurgerProjectMVC.UI.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UserRegisterVM, UserRegisterDTO>().ReverseMap();

            CreateMap<MenuDTO, MenuVM>().ReverseMap();
            CreateMap<MenuCreateVM, MenuCreateDTO>().ReverseMap();
            CreateMap<MenuUpdateVM, MenuUpdateDTO>().ReverseMap();
            CreateMap<MenuDTO, MenuUpdateVM>().ReverseMap();

            CreateMap<SauceDTO, SauceVM>().ReverseMap();
            CreateMap<SauceUpdateDTO, SauceUpdateVM>().ReverseMap();
            CreateMap<SauceCreateDTO, SauceCreateVM>().ReverseMap();
            CreateMap<SauceUpdateVM, SauceDTO>().ReverseMap();

            CreateMap<UserDTO, UserVM>().ReverseMap();
            CreateMap<UserUpdateVM, UserUpdateDTO>().ReverseMap();
            CreateMap<UserRegisterDTO, UserRegisterVM>().ReverseMap();
            CreateMap<UserLogInVM, UserLoginDTO>().ReverseMap();
            CreateMap<UserUpdateVM, UserDTO>().ReverseMap();

            CreateMap<OrderCreateDTO, OrderCreateVM>()
                .ForMember(dest => dest.SelectedSauceIds, opt => opt.Ignore())
                .ForMember(dest => dest.ActiveMenus, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<OrderCreateDTO, OrderVM>().ReverseMap();
        }

    }
}
