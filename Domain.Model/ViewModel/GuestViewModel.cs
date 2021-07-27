using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.ViewModel
{
    public class GuestViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal? Payment { get; set; }
    }
}
