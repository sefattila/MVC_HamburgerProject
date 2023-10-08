using AutoMapper;
using HamburgerProject.BLL.DTOs.SauceDTOs;
using HamburgerProject.BLL.SauceService;
using HampurgerProjectMVC.UI.Models.VMs.SauceVMs;
using Microsoft.AspNetCore.Mvc;

namespace HampurgerProjectMVC.UI.Controllers
{
    public class SauceController : Controller
    {
        private readonly ISauceService _sauceService;
        private readonly IMapper _mapper;

        public SauceController(ISauceService sauceService, IMapper mapper)
        {
            _sauceService = sauceService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            IList<SauceDTO> sauceDTOs = _sauceService.GetActive();
            IList<SauceVM> sauceVMs = _mapper.Map<IList<SauceVM>>(sauceDTOs);
            return View(sauceVMs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SauceCreateVM sauceCreateVM)
        {
            if(ModelState.IsValid)
            {
                SauceCreateDTO sauceCreateDTO=_mapper.Map<SauceCreateDTO>(sauceCreateVM);
                _sauceService.Create(sauceCreateDTO);
                return RedirectToAction("Index");
            }
            else
            {
                return BadRequest();
            }
        }

        public IActionResult Update(int id)
        {
            SauceDTO sauceDTO=_sauceService.GetById(id);
            SauceUpdateVM sauceUpdateVM=_mapper.Map<SauceUpdateVM>(sauceDTO);
            return View(sauceUpdateVM);
        }

        [HttpPost]
        public IActionResult Update(SauceUpdateVM updateVM)
        {
            if (ModelState.IsValid)
            {
                SauceUpdateDTO sauceUpdateDTO = _mapper.Map<SauceUpdateDTO>(updateVM);
                _sauceService.Update(sauceUpdateDTO);
                return RedirectToAction("Index");
            }
            else
                return BadRequest();
        }

        public IActionResult Delete(int id)
        {
            _sauceService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
