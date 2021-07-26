using AutoMapper;
using Domain.Model;
using Domain.Model.Payload;
using Domain.Model.ViewModel;
using Domain.Service.Interface;
using Infra.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{

    public class EventService : IEventService
    {
        private readonly IEventRepository EventRepository;
        private readonly IMapper Mapper;

        public EventService(IServiceProvider serviceProvider, IMapper mapper, IEventRepository eventRepository)
        {
            EventRepository = eventRepository;
            Mapper = mapper;
        }

        public EventViewModel Create(Guid id, EventPayload payload)
        {
            var entity = new Event()
            { 
                Id = Guid.NewGuid(), 
                Name = "Test" 
            };

            var newEntity = EventRepository.Create(id, payload);
            var viewModel = Mapper.Map<EventViewModel>(newEntity);           
            return viewModel;
        }
    }
}
