using Domain.Model.Entity;
using Domain.Model.Payload;
using Infra.Repository.Base;
using Infra.Repository.Context;
using Infra.Repository.Interface;

namespace Infra.Repository
{
    public class GuestRepository : BaseRepository<Guest>, IGuestRepository
    {
        public GuestRepository(EventContext context) : base(context)
        {

        }
    }
}
