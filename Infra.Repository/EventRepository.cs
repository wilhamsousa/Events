using Domain.Model;
using Domain.Model.Payload;
using Infra.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class EventRepository : IEventRepository
    {
        public Event Create(Guid id, EventPayload payload)
        {
            var entity = new Event()
            {
                Id = Guid.NewGuid(),
                Name = "Test"
            };

            return entity;
        }        
    }
}
