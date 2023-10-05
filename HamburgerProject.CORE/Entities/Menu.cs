using HamburgerProject.CORE.Abstract;
using HamburgerProject.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.CORE.Entities
{
    public class Menu:IBaseEntity
    {
        public int Id { get; set; }
        public string MenuName { get; set; }
        public double MenuPrice { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; } = Status.Active;

        //Nav Prop  
        public virtual ICollection<Order> Orders { get; set; }
    }
}
