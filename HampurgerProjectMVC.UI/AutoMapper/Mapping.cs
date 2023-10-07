using AutoMapper;
using HamburgerProject.BLL.DTOs.UserDTOs;
using HampurgerProjectMVC.UI.Models.VMs.UserVMs;

namespace HampurgerProjectMVC.UI.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<UserRegisterVM,UserRegisterDTO>().ReverseMap();
        }

    }
}
