using AutoMapper;
using HamburgerProject.BLL.DTOs.SauceDTOs;
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
        }
    }
}
