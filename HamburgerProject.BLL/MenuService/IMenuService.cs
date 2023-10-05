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
        void Create(Menu entity);
        void Update(Menu entity);
        void Delete(Menu entity);
        bool Any(Expression<Func<Menu, bool>> expression);
        Menu GetDefault(Expression<Func<Menu, bool>> expression);
        Menu GetDefaultById(int id);
        List<Menu> GetDefaults(Expression<Func<Menu, bool>> expression);
        List<Menu> GetAll();
    }
}
