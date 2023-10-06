﻿using HamburgerProject.BLL.DTOs.OrderDTOs;
using HamburgerProject.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.BLL.DTOs.MenuDTOs
{
    public class MenuCreateDTO
    {
        public string MenuName { get; set; }
        public double MenuPrice { get; set; }
    }
}
