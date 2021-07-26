using Domain.Model;
using Domain.Model.Payload;
using Infra.Repository.Base;
using Infra.Repository.Context;
using Infra.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(EventContext context) : base(context)
        {

        }
    }
}
