using HamburgerProject.BLL.DTOs.MenuDTOs;
using HamburgerProject.BLL.DTOs.SauceDTOs;
using HamburgerProject.CORE.Enums;
using HampurgerProjectMVC.UI.Models.VMs.MenuVMs;
using HampurgerProjectMVC.UI.Models.VMs.SauceVMs;
using System.ComponentModel.DataAnnotations;

namespace HampurgerProjectMVC.UI.Models.VMs.OrderVMs
{
    public class OrderCreateVM
    {
        public Sizes Size { get; set; }
        public int Quantity { get; set; }
        public int MenuId { get; set; }
        public string AppUserId { get; set; }
        public ICollection<int> SelectedSauceIds { get; set; }

        public IList<MenuVM>? ActiveMenus { get; set; }
        public IList<SauceVM>? ActiveSauces { get; set; }
    }
}
