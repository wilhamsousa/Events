using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ViewModel
{
    public class DashboardViewModel
    {
        public Guid EventId { get; set; }
        public string Description { get; set; }
        public string DateTime { get; set; }
        public int GuestCount { get; set; }
        public decimal TotalValue { get; set; }
    }
}
