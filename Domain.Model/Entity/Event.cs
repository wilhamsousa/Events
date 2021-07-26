using Domain.Model.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Event : BaseEntity
    {
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
    }
}
