using Domain.Model.Entity;
using Domain.Model.InputModel;
using Infra.Repository.Base;
using Infra.Repository.Context;
using Infra.Repository.Interface;

namespace Infra.Repository
{
    public class GuestRepository : BaseRepository<Domain.Model.Entity.Guest>, IGuestRepository
    {
        public GuestRepository(EventContext context) : base(context)
        {

        }
    }
}
