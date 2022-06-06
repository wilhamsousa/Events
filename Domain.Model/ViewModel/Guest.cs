using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ViewModel
{
    public class Guest
    {
        public Guid EventId { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal? Payment { get; set; }
    }
}
