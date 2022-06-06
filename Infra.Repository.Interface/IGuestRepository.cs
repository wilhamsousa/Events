using Domain.Model.Entity;
using Domain.Model.InputModel;
using Infra.Repository.Interface.Base;

namespace Infra.Repository.Interface
{
    public interface IGuestRepository : IBaseRepository<Domain.Model.Entity.Guest>
    {
    }
}
