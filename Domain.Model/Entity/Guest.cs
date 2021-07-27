using Domain.Model.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Entity
{
    public class Guest : BaseEntity
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public decimal? Payment { get; set; }

        public virtual Event Event { get; set; }
    }
}
