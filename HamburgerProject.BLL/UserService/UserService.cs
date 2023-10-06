using AutoMapper;
using HamburgerProject.BLL.DTOs.UserDTOs;
using HamburgerProject.CORE.Entities;
using HamburgerProject.CORE.Enums;
using HamburgerProject.REPOSITORY.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.BLL.UserService
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        private readonly IBaseRepo<AppUser> _baseRepo;

        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, IBaseRepo<AppUser> baseRepo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _baseRepo = baseRepo;
        }

        public async Task Create(UserRegisterDTO entity)
        {
            if (entity == null)
            {
                throw new Exception("User Boş");
            }
            AppUser appUser = _mapper.Map<AppUser>(entity);
            var result = await _userManager.CreateAsync(appUser, entity.Password);
            if (!result.Succeeded)
            {
                throw new Exception("Kullanıcı Eklerken Hata");
            }
        }

        public async Task Delete(string id)
        {
            if (id == null)
            {
                throw new Exception("Id Boş");
            }
            if (_baseRepo.Any(x => x.Id == id))
            {
                throw new Exception("Böyle Bir Id Yok");
            }
            AppUser appUser = await _userManager.FindByIdAsync(id);
            appUser.DeleteDate = DateTime.Now;
            appUser.Status = Status.Active;
            var result = await _userManager.UpdateAsync(appUser);
            if (!result.Succeeded)
            {
                throw new Exception("Kullanıcı Silerken Hata");
            }
        }

        public IList<UserDTO> GetActive()
        {
            IList<AppUser> appUsers = _baseRepo.GetDefaults(x => x.Status != Status.Passive);
            IList<UserDTO> userDTOs = _mapper.Map<IList<AppUser>, IList<UserDTO>>(appUsers);
            return userDTOs;
        }

        public IList<UserDTO> GetAll()
        {
            IList<AppUser> appUsers = _baseRepo.GetAll();
            IList<UserDTO> userDTOs = _mapper.Map<IList<AppUser>, IList<UserDTO>>(appUsers);
            return userDTOs;
        }

        public bool IsIdExist(string id)
        {
            return _baseRepo.Any(x => x.Id == id);
        }

        public Task Update(UserUpdateDTO entity)
        {
            throw new NotImplementedException();
        }
    }
}
