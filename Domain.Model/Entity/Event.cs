using Domain.Model.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entity
{
    public class Event : BaseEntity
    {
        public Event()
        {
            Guest = new HashSet<Guest>();
        }

        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public string Observation { get; set; }
        public decimal PriceWithDrink { get; set; }
        public decimal PriceWithoutDrink { get; set; }

        public virtual ICollection<Guest> Guest { get; set; }
    }
}
