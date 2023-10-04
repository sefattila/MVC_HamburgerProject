using HamburgerProject.CORE.Abstract;
using HamburgerProject.CORE.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.CORE.Entities
{
    public class AppUser : IdentityUser, IBaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; }


        //Nav Prop
        public virtual ICollection<Order> Orders { get; set; }
    }
}
