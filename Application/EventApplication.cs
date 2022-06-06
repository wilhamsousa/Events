using Application.Interface;
using Domain.Model.InputModel;
using Domain.Model.ViewModel;
using Domain.Service.Interface;
using System;
using System.Collections.Generic;

namespace Application
{
    public class EventApplication : IEventApplication
    {
        private readonly IEventService EventService;

        public EventApplication(IEventService eventService, IServiceProvider serviceProvider)
        {
            EventService = eventService;
        }

        public Domain.Model.ViewModel.Event Create(Domain.Model.InputModel.Event payload)
        {
            var result = EventService.Create(payload);
            return result;
        }

        public void Update(Guid id, Domain.Model.InputModel.Event payload)
        {
            EventService.Update(id, payload);
        }

        public Domain.Model.ViewModel.Event Read(Guid id)
        {
            var result = EventService.Read(id);
            return result;
        }

        public void Delete(Guid id)
        {
            EventService.Delete(id);
        }

        public IEnumerable<Domain.Model.ViewModel.Event> List()
        {
            var result = EventService.List();
            return result;
        }

        public IEnumerable<Dashboard> Dashboard()
        {
            var result = EventService.Dashboard();
            return result;
        }
    }
}
