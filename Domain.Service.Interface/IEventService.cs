using Domain.Model.Payload;
using Domain.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.Interface
{
    public interface IEventService
    {
        EventViewModel Create(Guid id, EventPayload payload);
        void Update(Guid id, EventPayload payload);
        EventViewModel Read(Guid id);
        void Delete(Guid id);
        IEnumerable<EventViewModel> List();
    }
}
