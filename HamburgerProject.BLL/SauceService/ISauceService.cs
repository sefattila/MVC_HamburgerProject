using HamburgerProject.BLL.DTOs.SauceDTOs;
using HamburgerProject.CORE.Entities;
using HamburgerProject.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.BLL.SauceService
{
    public interface ISauceService
    {
        void Create(SauceCreateDTO entity);
        void Update(SauceUpdateDTO entity);
        void Delete(int id);
        bool IsIdExist(string sauceName);
        //SauceListDTO GetDefault(string sauceName);
        //SauceListDTO GetDefaultById(int id);
        IList<SauceDTO> GetActive();
        IList<SauceDTO> GetAll();
        SauceDTO GetById(int id);
    }
}
