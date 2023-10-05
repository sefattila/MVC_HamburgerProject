using HamburgerProject.BLL.DTOs.SauceDTOs;
using HamburgerProject.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.BLL.DTOs.OrderDTOs
{
    public class OrderCreateDTO
    {
        public Sizes Size { get; set; }
        public int Quantity { get; set; }
        public string AppUserId { get; set; }
        public int MenuId { get; set; }
        public ICollection<SauceDTO> SauceDTOs { get; set; }
    }
}
