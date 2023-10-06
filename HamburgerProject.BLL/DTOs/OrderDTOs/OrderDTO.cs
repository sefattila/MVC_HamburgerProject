using HamburgerProject.BLL.DTOs.SauceDTOs;
using HamburgerProject.CORE.Entities;
using HamburgerProject.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.BLL.DTOs.OrderDTOs
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public Sizes Size { get; set; }
        public int Quantity { get; set; }
        public ICollection<SauceDTO> SauceDTOs { get; set; }
        public AppUser AppUser { get; set; }
    }
}
