using HamburgerProject.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.BLL.DTOs.SauceDTOs
{
    public class SauceUpdateDTO
    {
        public int Id { get; set; }
        public string SauceName { get; set; }
        public double SaucePrice { get; set; }
    }
}
