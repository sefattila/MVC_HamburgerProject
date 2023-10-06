using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.BLL.DTOs.MenuDTOs
{
    public class MenuUpdateDTO
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public double MenuPrice { get; set; }
    }
}
