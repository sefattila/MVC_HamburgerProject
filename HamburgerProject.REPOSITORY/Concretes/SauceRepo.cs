using HamburgerProject.CORE.Entities;
using HamburgerProject.REPOSITORY.Contexts;
using HamburgerProject.REPOSITORY.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.REPOSITORY.Concretes
{
    public class SauceRepo : BaseRepo<Sauce>, ISauceRepo
    {
        private readonly AppDbContext _context;
        public SauceRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
