using AutoMapper;
using HamburgerProject.BLL.DTOs.MenuDTOs;
using HamburgerProject.BLL.DTOs.OrderDTOs;
using HamburgerProject.BLL.DTOs.SauceDTOs;
using HamburgerProject.BLL.MenuService;
using HamburgerProject.BLL.OrderService;
using HamburgerProject.BLL.SauceService;
using HamburgerProject.REPOSITORY.Contexts;
using HampurgerProjectMVC.UI.Models.VMs.MenuVMs;
using HampurgerProjectMVC.UI.Models.VMs.OrderVMs;
using HampurgerProjectMVC.UI.Models.VMs.SauceVMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace HampurgerProjectMVC.UI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMenuService _menuService;
        private readonly ISauceService _sauceService;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public OrderController(IOrderService orderService, IMapper mapper, IMenuService menuService, ISauceService sauceService, AppDbContext context)
        {
            _orderService = orderService;
            _mapper = mapper;
            _menuService = menuService;
            _sauceService = sauceService;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CurrentUserOrders()
        {
            return View();
        }

        public IActionResult Create()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var menuDTOs = _menuService.GetActive();
            var sauceDTOs = _sauceService.GetActive();

            List<MenuVM> menuVMs = _mapper.Map<List<MenuVM>>(menuDTOs);
            List<SauceVM> sauceVMs = _mapper.Map<List<SauceVM>>(sauceDTOs);

            OrderCreateVM orders = new OrderCreateVM
            {
                ActiveMenus = menuVMs,
                ActiveSauces = sauceVMs,
                AppUserId = userId
            };
            return View(orders);
        }

        [HttpPost]
        public IActionResult Create(OrderCreateVM orderCreateVM)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                OrderCreateDTO orderCreateDTO = _mapper.Map<OrderCreateDTO>(orderCreateVM);
                orderCreateDTO.AppUserId = userId;
                _orderService.Create(orderCreateDTO);

                OrderVM orderVM = _mapper.Map<OrderVM>(orderCreateDTO);
                var order = _orderService.GetById(orderVM.Id);

                foreach (var sauceId in orderCreateVM.SelectedSauceIds)
                {
                    var sauceDTO = _sauceService.GetById(sauceId); 
                    order.SauceDTOs.Add(sauceDTO);
                }
                _context.SaveChanges();

                return RedirectToAction("Index","Home");
            }
            return View();
        }
    }
}
