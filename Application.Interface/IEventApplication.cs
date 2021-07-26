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
        EventViewModel Create(Guid id, EventPayload payload);
    }
}
