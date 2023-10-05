using HamburgerProject.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.BLL.OrderService
{
    public interface IOrderService
    {
        void Create(Order entity);
        void Update(Order entity);
        void Delete(Order entity);
        bool Any(Expression<Func<Order, bool>> expression);
        Order GetDefault(Expression<Func<Order, bool>> expression);
        Order GetDefaultById(int id);
        List<Order> GetDefaults(Expression<Func<Order, bool>> expression);
        List<Order> GetAll();
    }
}
