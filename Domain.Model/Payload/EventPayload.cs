using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Payload
{
    public class EventPayload
    {
        public string Description { get; set; }
        public string DateTime { get; set; }
        public string Observation { get; set; }
        public string PriceWithDrink { get; set; }
        public string PriceWithoutDrink { get; set; }
    }
}
