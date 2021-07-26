using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ViewModel
{
    public class EventViewModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string DateTime { get; set; }
    }
}
