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
    public class OrderRepo : BaseRepo<Order>, IOrderRepo
    {
        private readonly AppDbContext _context;
        public OrderRepo(AppDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
