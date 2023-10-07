using AutoMapper;
using HamburgerProject.BLL.DTOs.UserDTOs;
using HamburgerProject.BLL.UserService;
using HampurgerProjectMVC.UI.Models.VMs.UserVMs;
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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserRegisterVM registerVM)
        {
            if(ModelState.IsValid)
            {
                UserRegisterDTO userRegisterDTO= _mapper.Map<UserRegisterDTO>(registerVM);
                var result=await _userService.Create(userRegisterDTO,registerVM.Password);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
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
    }
}
