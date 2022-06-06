using Domain.Model.Entity;
using Domain.Model.InputModel;
using Domain.Model.ViewModel;
using Infra.Repository.Interface.Base;
using System.Collections.Generic;

namespace Infra.Repository.Interface
{
    public interface IEventRepository : IBaseRepository<Domain.Model.Entity.Event>
    {
        IEnumerable<Dashboard> Dashboard();
    }
}
