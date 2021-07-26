using Domain.Model;
using Domain.Model.Payload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository.Interface
{
    public interface IEventRepository
    {
        Event Create(Guid id, EventPayload payload);
    }
}
