using Domain.Model.Entity;
using Domain.Model.Payload;
using Domain.Model.ViewModel;
using Infra.Repository.Interface.Base;
using System.Collections.Generic;

namespace Infra.Repository.Interface
{
    public interface IEventRepository : IBaseRepository<Event>
    {
        IEnumerable<DashboardViewModel> Dashboard();
    }
}
