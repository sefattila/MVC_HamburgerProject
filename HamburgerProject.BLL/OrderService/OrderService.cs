using AutoMapper;
using HamburgerProject.BLL.DTOs.MenuDTOs;
using HamburgerProject.BLL.DTOs.OrderDTOs;
using HamburgerProject.CORE.Entities;
using HamburgerProject.CORE.Enums;
using HamburgerProject.REPOSITORY.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.BLL.OrderService
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _repo;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void Create(OrderCreateDTO entity)
        {
            Order order=_mapper.Map<Order>(entity);
            _repo.Create(order);
        }

        public void Delete(int id)
        {
            Order order=_repo.GetDefaultById(id);
            order.DeleteDate = DateTime.Now;
            order.Status = Status.Passive;
            _repo.Delete(order);
        }

        public IList<OrderDTO> GetActive()
        {
            IList<Order> orders = _repo.GetDefaults(x => x.Status != Status.Passive);
            IList<OrderDTO> orderDTOs=_mapper.Map<IList<Order>,IList<OrderDTO>>(orders);
            return orderDTOs;
        }

        public IList<OrderDTO> GetAll()
        {
            IList<Order> orders = _repo.GetAll();
            IList<OrderDTO> orderDTOs = _mapper.Map<IList<Order>, IList<OrderDTO>>(orders);
            return orderDTOs;
        }

        public OrderDTO GetById(int id)
        {
            return _mapper.Map<OrderDTO>(_repo.GetDefaultById(id));
        }

        public bool IsIdExist(int id)
        {
            return _repo.Any(x => x.Id == id);
        }

        public void Update(OrderUpdateDTO entity)
        {
            Order order=_mapper.Map<Order>(entity);
            order.UpdateDate = DateTime.Now;
            order.Status = Status.Modified;
            _repo.Update(order);
        }
    }
}
