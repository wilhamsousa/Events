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
            var newEntity = Mapper.Map<Event>(payload);
            var entity = EventRepository.Create(newEntity);
            var viewModel = Mapper.Map<EventViewModel>(entity);
            return viewModel;
        }        

        public EventViewModel Read(Guid id)
        {
            var entity = EventRepository.Read(id);
            var viewModel = Mapper.Map<EventViewModel>(entity);
            return viewModel;
        }
        public void Update(Guid id, EventPayload payload)
        {
            var newEntity = Mapper.Map<Event>(payload);
            newEntity.Id = id;
            EventRepository.Update(newEntity);
        }

        public void Delete(Guid id)
        {
            EventRepository.Delete(id);
        }

        public IEnumerable<EventViewModel> List()
        {
            var entity = EventRepository.List();
            var viewModel = Mapper.Map<IEnumerable<EventViewModel>>(entity);
            return viewModel;
        }
    }
}
