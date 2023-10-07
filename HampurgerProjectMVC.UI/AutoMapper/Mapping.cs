using AutoMapper;
using HamburgerProject.BLL.DTOs.MenuDTOs;
using HamburgerProject.BLL.DTOs.UserDTOs;
using HampurgerProjectMVC.UI.Models.VMs.MenuVMs;
using HampurgerProjectMVC.UI.Models.VMs.UserVMs;

namespace HampurgerProjectMVC.UI.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UserRegisterVM,UserRegisterDTO>().ReverseMap();

            CreateMap<MenuVM, MenuDTO>().ReverseMap();
            CreateMap<MenuCreateVM, MenuCreateDTO>().ReverseMap();
            CreateMap<MenuUpdateVM, MenuUpdateDTO>().ReverseMap();
        }

    }
}
