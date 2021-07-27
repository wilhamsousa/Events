using Domain.Model.Entity;
using Domain.Model.Payload;
using Infra.Repository.Interface.Base;

namespace Infra.Repository.Interface
{
    public interface IGuestRepository : IBaseRepository<Guest>
    {
    }
}
