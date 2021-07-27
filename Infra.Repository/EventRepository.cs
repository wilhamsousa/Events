using Domain.Model.Entity;
using Domain.Model.Payload;
using Infra.Repository.Base;
using Infra.Repository.Context;
using Infra.Repository.Interface;

namespace Infra.Repository
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(EventContext context) : base(context)
        {

        }
    }
}
