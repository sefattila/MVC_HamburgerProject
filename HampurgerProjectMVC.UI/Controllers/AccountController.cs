using AutoMapper;
using HamburgerProject.BLL.DTOs.UserDTOs;
using HamburgerProject.BLL.UserService;
using HampurgerProjectMVC.UI.Models.VMs.UserVMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HampurgerProjectMVC.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AccountController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [Authorize(Roles ="admin")]
        public IActionResult Index()
        {
            IList<UserDTO> users = _userService.GetActive();
            IList<UserVM> userVMs = _mapper.Map<IList<UserVM>>(users);
            return View(userVMs);
        }

        [Authorize(Roles = "admin,user")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "admin,user")]
        [HttpPost]
        public async Task<IActionResult> Create(UserRegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                UserRegisterDTO userRegisterDTO = _mapper.Map<UserRegisterDTO>(registerVM);
                var result = await _userService.Create(userRegisterDTO, registerVM.Password);
                if (result.Succeeded)
                    return RedirectToAction("LogIn");
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description.ToString());
                    }
                }
            }
            return View();
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Update(string id)
        {
            UserDTO userDTO = await _userService.GetById(id);
            UserUpdateVM userUpdateVM = _mapper.Map<UserUpdateVM>(userDTO);
            return View(userUpdateVM);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateVM updateVM)
        {
            if (ModelState.IsValid)
            {
                UserUpdateDTO userUpdateDTO = _mapper.Map<UserUpdateDTO>(updateVM);
                await _userService.Update(userUpdateDTO);
                return RedirectToAction("Index");
            }
            else
                return BadRequest();
        }

        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(string id)
        {
            await _userService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(UserLogInVM userLogInVM)
        {
            if (ModelState.IsValid)
            {
                UserLoginDTO userLoginDTO=_mapper.Map<UserLoginDTO>(userLogInVM);
                await _userService.LogIn(userLoginDTO);
                return RedirectToAction("Index", "Home");
            }
            else 
                return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await _userService.LogOut();
            return RedirectToAction("LogIn");
        }
    }
}
