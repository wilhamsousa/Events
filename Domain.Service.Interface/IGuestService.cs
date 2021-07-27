using Domain.Model.Payload;
using Domain.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Interface
{
    public interface IGuestService
    {
        GuestViewModel Create(GuestPayload payload);
        void Update(Guid id, GuestPayload payload);
        GuestViewModel Read(Guid id);
        void Delete(Guid id);
        IEnumerable<GuestViewModel> List();
    }
}
