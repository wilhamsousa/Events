using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Payload;
using Domain.Model.ViewModel;

namespace Application.Interface
{
    public interface IEventApplication
    {
        EventViewModel Create(EventPayload payload);
        EventViewModel Read(Guid id);
        void Update(Guid id, EventPayload payload);
        void Delete(Guid id);
        IEnumerable<EventViewModel> List();
        IEnumerable<DashboardViewModel> Dashboard();
    }
}
