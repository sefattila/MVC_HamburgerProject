using HamburgerProject.BLL.DTOs.SauceDTOs;
using HamburgerProject.BLL.DTOs.UserDTOs;
using HamburgerProject.CORE.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.BLL.UserService
{
    public interface IUserService
    {
        Task Create(UserRegisterDTO entity);
        Task Update(UserUpdateDTO entity);
        Task Delete(string id);
        bool IsIdExist(string id);
        //SauceListDTO GetDefault(string sauceName);
        //SauceListDTO GetDefaultById(int id);
        IList<UserDTO> GetActive();
        IList<UserDTO> GetAll();
    }
}
