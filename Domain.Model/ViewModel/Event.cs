using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ViewModel
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string DateTime { get; set; }
        public string PriceWithDrink { get; set; }
        public string PriceWithoutDrink { get; set; }
    }
}
