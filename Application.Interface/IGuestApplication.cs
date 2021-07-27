using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Payload;
using Domain.Model.ViewModel;

namespace Application.Interface
{
    public interface IGuestApplication
    {
        GuestViewModel Create(GuestPayload payload);
        GuestViewModel Read(Guid id);
        void Update(Guid id, GuestPayload payload);
        void Delete(Guid id);
        IEnumerable<GuestViewModel> List();
    }
}
