using AutoMapper;
using HamburgerProject.BLL.DTOs.MenuDTOs;
using HamburgerProject.CORE.Entities;
using HamburgerProject.CORE.Enums;
using HamburgerProject.REPOSITORY.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.BLL.MenuService
{
    public class MenuService : IMenuService
    {
        private readonly IMenuRepo _repo;
        private readonly IMapper _mapper;

        public MenuService(IMenuRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public void Create(MenuCreateDTO entity)
        {
            Menu menu=_mapper.Map<Menu>(entity);
            _repo.Create(menu);
        }

        public void Delete(int id)
        {
            Menu menu=_repo.GetDefaultById(id);
            menu.DeleteDate = DateTime.Now;
            menu.Status = Status.Passive;
            _repo.Delete(menu);
        }

        public IList<MenuDTO> GetActive()
        {
            IList<Menu> menus = _repo.GetDefaults(x => x.Status != Status.Passive);
            IList<MenuDTO> menuDTOs = _mapper.Map<IList<Menu>, IList<MenuDTO>>(menus);
            return menuDTOs;
        }

        public IList<MenuDTO> GetAll()
        {
            IList<Menu> menus = _repo.GetAll();
            IList<MenuDTO> menuDTOs = _mapper.Map<IList<Menu>, IList<MenuDTO>>(menus);
            return menuDTOs;
        }

        public MenuDTO GetById(int id)
        {
            return _mapper.Map<MenuDTO>(_repo.GetDefaultById(id));
        }

        public bool IsIdExist(string menuName)
        {
            return _repo.Any(x=>x.MenuName== menuName);
        }

        public void Update(MenuUpdateDTO entity)
        {
            Menu menu = _mapper.Map<Menu>(entity);
            menu.UpdateDate = DateTime.Now;
            menu.Status = Status.Modified;
            _repo.Update(menu);
        }
    }
}
