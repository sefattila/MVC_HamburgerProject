using HamburgerProject.CORE.Abstract;
using HamburgerProject.CORE.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.CORE.Entities
{
    public class Sauce : IBaseEntity
    {
        public int Id { get; set; }
        public string SauceName { get; set; }
        public double SaucePrice { get; set; }
        public DateTime CreateDate { get; set; }= DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Status Status { get; set; } = Status.Active;
        public int OrderId { get; set; }

        //Nav Prop
        public virtual Order Order { get; set; }
    }
}
