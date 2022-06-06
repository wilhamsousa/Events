using Domain.Model.Entity;
using Domain.Model.InputModel;
using Domain.Model.ViewModel;
using Infra.Repository.Base;
using Infra.Repository.Context;
using Infra.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Repository
{
    public class EventRepository : BaseRepository<Domain.Model.Entity.Event>, IEventRepository
    {
        public EventRepository(EventContext context) : base(context)
        {

        }

        public IEnumerable<Dashboard> Dashboard()
        {
            var result = (from e in Context.Event
                          join u in Context.Guest on e.Id equals u.EventId into u2
                          from u3 in u2.DefaultIfEmpty()
                          group u3 by new { e.Id, e.Description, e.DateTime } into ge
                          orderby ge.Key.DateTime descending
                          select new Dashboard()
                          {
                              EventId = ge.Key.Id,
                              Description = ge.Key.Description,
                              DateTime = ge.Key.DateTime.ToString(),
                              TotalValue = ge.Sum(s => s.Payment??0),
                              GuestCount = ge.Count(s => s.Name != null)
                          }
                ).AsNoTracking().ToList();

            //var result = Context.Guest
            //    .Include(x => x.Event)
            //    .GroupBy(x => new { x.Event.Id, x.Event.Description, x.Event.DateTime })
            //    .Select(x => new DashboardViewModel()
            //    {
            //        EventId = x.Key.Id,
            //        Description = x.Key.Description,
            //        DateTime = x.Key.DateTime.ToString(),
            //        TotalValue = x.Sum(g => g.Payment ?? 0),
            //        GuestCount = x.Count()
            //    })
            //    .ToList();
            return result;
        }
    }
}
