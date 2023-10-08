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
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IAppUserRepo _userRepo;

        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMapper mapper, IAppUserRepo userRepo)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _userRepo = userRepo;
        }

        public async Task<IdentityResult> Create(UserRegisterDTO entity, string Password)
        {
            if (entity == null)
            {
                throw new Exception("User Boş");
            }
            AppUser appUser = _mapper.Map<AppUser>(entity);

            var result = await _userManager.CreateAsync(appUser, Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(appUser, "user");
            }

            return result;
        }

        public async Task Delete(string id)
        {
            if (id == null)
            {
                throw new Exception("Id Boş");
            }
            if (!_userRepo.Any(x => x.Id == id))
            {
                throw new Exception("Böyle Bir Id Yok");
            }
            AppUser appUser = await _userManager.FindByIdAsync(id);
            appUser.DeleteDate = DateTime.Now;
            appUser.Status = Status.Passive;
            await _userManager.UpdateAsync(appUser);

        }

        public IList<UserDTO> GetActive()
        {
            IList<AppUser> appUsers = _userRepo.GetDefaults(x => x.Status != Status.Passive);
            IList<UserDTO> userDTOs = _mapper.Map<IList<AppUser>, IList<UserDTO>>(appUsers);
            return userDTOs;
        }

        public IList<UserDTO> GetAll()
        {
            IList<AppUser> appUsers = _userRepo.GetAll();
            IList<UserDTO> userDTOs = _mapper.Map<IList<AppUser>, IList<UserDTO>>(appUsers);
            return userDTOs;
        }

        public async Task<UserDTO> GetById(string id)
        {
            AppUser appUser = await _userManager.FindByIdAsync(id);
            return _mapper.Map<UserDTO>(appUser);
        }

        public bool IsIdExist(string id)
        {
            return _userRepo.Any(x => x.Id == id);
        }

        public async Task LogIn(UserLoginDTO login)
        {
            if (login == null)
                throw new Exception("Login Entity Boş");
            AppUser appUser = await _userManager.FindByNameAsync(login.UserName);
            if (appUser == null)
                throw new Exception("Böyle Bir Kullanıcı Yok");
            await _signInManager.PasswordSignInAsync(appUser, login.Password, true, false);
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task Update(UserUpdateDTO entity)
        {
            if (entity == null)
                throw new Exception("Update Entity Boş");

            AppUser updateUser = await _userManager.FindByIdAsync(entity.Id);
            if (updateUser == null)
                throw new Exception("Kullanıcı bulunamadı");

            _mapper.Map(entity, updateUser);

            updateUser.UpdateDate = DateTime.Now;
            updateUser.Status = Status.Modified;

            await _userManager.UpdateAsync(updateUser);


            //if (entity == null)
            //    throw new Exception("Update Entity Boş");
            //AppUser appUser = _mapper.Map<AppUser>(entity);
            //appUser.UpdateDate = DateTime.Now;
            //appUser.Status = Status.Modified;
            //await _userManager.UpdateAsync(appUser);
        }
    }
}
