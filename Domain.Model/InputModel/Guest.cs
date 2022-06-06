using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.InputModel
{
    public class Guest
    {
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public decimal? Payment { get; set; }
    }
}
