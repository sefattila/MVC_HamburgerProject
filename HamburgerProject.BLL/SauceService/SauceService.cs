using AutoMapper;
using HamburgerProject.BLL.DTOs.SauceDTOs;
using HamburgerProject.CORE.Entities;
using HamburgerProject.CORE.Enums;
using HamburgerProject.REPOSITORY.Contexts;
using HamburgerProject.REPOSITORY.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.BLL.SauceService
{
    public class SauceService : ISauceService
    {
        private readonly ISauceRepo _repo;
        private readonly IMapper _mapper;

        public SauceService(IMapper mapper, ISauceRepo repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        public void Create(SauceCreateDTO entity)
        {
            Sauce sauce = _mapper.Map<Sauce>(entity);
            _repo.Create(sauce);
        }

        public void Delete(int id)
        {
            Sauce sauce = _repo.GetDefaultById(id);
            sauce.DeleteDate = DateTime.Now;
            sauce.Status = Status.Passive;
            _repo.Delete(sauce);
        }

        public IList<SauceDTO> GetActive()
        {
            IList<Sauce> sauces = _repo.GetDefaults(x => x.Status != Status.Passive);
            IList<SauceDTO> sauceDTOs = _mapper.Map<IList<Sauce>, IList<SauceDTO>>(sauces);
            return sauceDTOs;
        }

        public IList<SauceDTO> GetAll()
        {
            IList<Sauce> sauces = _repo.GetAll();
            IList<SauceDTO> sauceDTOs = _mapper.Map<IList<Sauce>, IList<SauceDTO>>(sauces);
            return sauceDTOs;
        }

        public bool IsIdExist(string sauceName)
        {
            return _repo.Any(x=>x.SauceName==sauceName);
        }

        public void Update(SauceUpdateDTO entity)
        {
            Sauce sauce=_mapper.Map<Sauce>(entity);
            sauce.UpdateDate = DateTime.Now;
            sauce.Status = Status.Modified;
            _repo.Update(sauce);
        }
    }
}
