using Application.Interface;
using Domain.Model.Payload;
using Domain.Model.ViewModel;
using Domain.Service.Interface;
using System;

namespace Application
{
    public class EventApplication : IEventApplication
    {
        private readonly IEventService EventService;

        public EventApplication(IEventService eventService, IServiceProvider serviceProvider)
        {
            EventService = eventService;
        }

        public EventViewModel Create(Guid id, EventPayload payload)
        {
            var result = EventService.Create(id, payload);
            return result;
        }
    }
}
