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
    }
}
