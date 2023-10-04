using HamburgerProject.CORE.Abstract;
using HamburgerProject.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.CORE.Entities
{
    public class Order : IBaseEntity
    {
        public int Id { get; set; }
        public Sizes Size { get; set; } = Sizes.Little;
        public int Quantity { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; } = Status.Active;
        public string AppUserId { get; set; }

        //Nav Prop
        public virtual ICollection<Menu> Menus { get; set; }
        public virtual ICollection<Sauce> Sauces { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
