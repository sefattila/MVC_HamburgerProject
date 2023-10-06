using HamburgerProject.BLL.DTOs.OrderDTOs;
using HamburgerProject.BLL.DTOs.SauceDTOs;
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
        void Create(OrderCreateDTO entity);
        void Update(OrderUpdateDTO entity);
        void Delete(int id);
        bool IsIdExist(int id);
        IList<OrderDTO> GetActive();
        IList<OrderDTO> GetAll();
    }
}
