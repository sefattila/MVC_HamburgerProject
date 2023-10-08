using AutoMapper;
using HamburgerProject.BLL.DTOs.MenuDTOs;
using HamburgerProject.BLL.MenuService;
using HampurgerProjectMVC.UI.Models.VMs.MenuVMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HampurgerProjectMVC.UI.Controllers
{
    [Authorize(Roles = "admin")]
    public class MenuController : Controller
    {
        private readonly IMenuService _menuService;
        private readonly IMapper _mapper;

        public MenuController(IMenuService menuService, IMapper mapper)
        {
            _menuService = menuService;
            _mapper = mapper;
        }

        
        public IActionResult Index()
        {
            IList<MenuDTO> menuDTO = _menuService.GetActive();
            IList<MenuVM> menuVM = _mapper.Map<IList<MenuVM>>(menuDTO);
            return View(menuVM);
        }

        //[Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }

        //[Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Create(MenuCreateVM menuVM)
        {
            if (ModelState.IsValid)
            {
                MenuCreateDTO menuDTO=_mapper.Map<MenuCreateDTO>(menuVM);
                _menuService.Create(menuDTO);
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest();
            }
        }

        //[Authorize(Roles = "admin")]
        public IActionResult Update(int id)
        {
            var updateDTO=_menuService.GetById(id);
            MenuUpdateVM menuVM=_mapper.Map<MenuUpdateVM>(updateDTO);
            return View(menuVM);
        }

        //[Authorize(Roles = "admin")]
        [HttpPost]
        public IActionResult Update(MenuUpdateVM menuVM)
        {
            if (ModelState.IsValid)
            {
                var menuDTO = _mapper.Map<MenuUpdateDTO>(menuVM);
                _menuService.Update(menuDTO);
                return RedirectToAction("Index");
            }
            else
                return BadRequest();
        }

        //[Authorize(Roles = "admin")]
        public IActionResult Delete(int id)
        {
            _menuService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
