using AutoMapper;
using HamburgerProject.BLL.DTOs.MenuDTOs;
using HamburgerProject.BLL.DTOs.SauceDTOs;
using HamburgerProject.BLL.DTOs.UserDTOs;
using HampurgerProjectMVC.UI.Models.VMs.MenuVMs;
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
            CreateMap<UserUpdateVM,UserDTO>().ReverseMap();
        }

    }
}
