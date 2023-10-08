using HamburgerProject.BLL.DTOs.SauceDTOs;
using HamburgerProject.CORE.Entities;
using HamburgerProject.CORE.Enums;

namespace HampurgerProjectMVC.UI.Models.VMs.OrderVMs
{
    public class OrderVM
    {
        public int Id { get; set; }
        public Sizes Size { get; set; }
        public int Quantity { get; set; }
        public ICollection<SauceDTO> SauceDTOs { get; set; }
        public AppUser AppUser { get; set; }
    }
}
