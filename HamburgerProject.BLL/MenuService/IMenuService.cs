using HamburgerProject.BLL.DTOs.MenuDTOs;
using HamburgerProject.BLL.DTOs.OrderDTOs;
using HamburgerProject.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.BLL.MenuService
{
    public interface IMenuService
    {
        void Create(MenuCreateDTO entity);
        void Update(MenuUpdateDTO entity);
        void Delete(int id);
        bool IsIdExist(string menuName);
        IList<MenuDTO> GetActive();
        IList<MenuDTO> GetAll();
    }
}
