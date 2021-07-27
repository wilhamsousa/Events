using AutoMapper;
using Domain.Model.Entity;
using Domain.Model.Payload;
using Domain.Model.ViewModel;
using Domain.Service.Interface;
using Infra.Helpers;
using Infra.Repository.Interface;
using System;
using System.Collections.Generic;

namespace Domain.Service
{

    public class EventService : IEventService
    {
        private readonly IEventRepository EventRepository;
        private readonly IMapper Mapper;
        private readonly IServiceProvider ServiceProvider;

        public EventService(IServiceProvider serviceProvider, IMapper mapper, IEventRepository eventRepository)
        {
            EventRepository = eventRepository;
            Mapper = mapper;
            ServiceProvider = serviceProvider;
        }

        public EventViewModel Create(EventPayload payload)
        {
            CreateValidations(payload);
            var newEntity = Mapper.Map<Event>(payload);
            var entity = EventRepository.Create(newEntity);
            var viewModel = Mapper.Map<EventViewModel>(entity);
            return viewModel;
        }

        private void CreateValidations(EventPayload payload)
        {
            if (string.IsNullOrEmpty(payload.Description))
                throw new Exception("Descrição não informada.");

            if (string.IsNullOrEmpty(payload.DateTime))
                throw new Exception("Data não informada.");

            if (!Validators.IsDateTime(payload.DateTime))
                throw new Exception("Data inválida.");

            if (string.IsNullOrEmpty(payload.PriceWithDrink))
                throw new Exception("Preço com bebida não informado.");

            if (string.IsNullOrEmpty(payload.PriceWithoutDrink))
                throw new Exception("Preço sem bebida não informado.");

            if (!Validators.IsNumber(payload.PriceWithDrink) || Decimal.Parse(payload.PriceWithDrink) < 0)
                throw new Exception("Preço com bebida inválido.");

            if (!Validators.IsNumber(payload.PriceWithoutDrink) || Decimal.Parse(payload.PriceWithoutDrink) < 0)
                throw new Exception("Preço sem bebida inválido.");

            var exist = EventRepository.Exists(x => x.Description == payload.Description);
            if (exist)
                throw new Exception("Este evento já existe.");
        }

        public EventViewModel Read(Guid id)
        {
            ReadValidations(id);
            var entity = EventRepository.Read(id);
            var viewModel = Mapper.Map<EventViewModel>(entity);
            return viewModel;
        }

        private void ReadValidations(Guid id)
        {
            if (id == Guid.Empty)
                throw new Exception("Id não informado.");
        }

        public void Update(Guid id, EventPayload payload)
        {
            UpdateValidations(id, payload);
            var newEntity = Mapper.Map<Event>(payload);
            newEntity.Id = id;
            EventRepository.Update(newEntity);
        }

        private void UpdateValidations(Guid id, EventPayload payload)
        {
            if (id == Guid.Empty)
                throw new Exception("Id não informado.");

            if (string.IsNullOrEmpty(payload.Description))
                throw new Exception("Descrição não informada.");

            if (string.IsNullOrEmpty(payload.DateTime))
                throw new Exception("Data não informada.");

            if (!Validators.IsDateTime(payload.DateTime))
                throw new Exception("Data inválida.");

            if (string.IsNullOrEmpty(payload.PriceWithDrink))
                throw new Exception("Preço com bebida não informado.");

            if (string.IsNullOrEmpty(payload.PriceWithoutDrink))
                throw new Exception("Preço sem bebida não informado.");

            if (!Validators.IsNumber(payload.PriceWithDrink) || Decimal.Parse(payload.PriceWithDrink) < 0)
                throw new Exception("Preço com bebida inválido.");

            if (!Validators.IsNumber(payload.PriceWithoutDrink) || Decimal.Parse(payload.PriceWithoutDrink) < 0)
                throw new Exception("Preço sem bebida inválido.");

            var exist = EventRepository.Exists(x => x.Id == id);
            if (!exist)
                throw new Exception("Registro não encontrado.");
        }

        public void Delete(Guid id)
        {
            DeleteValidations(id);
            EventRepository.Delete(id);
        }

        private void DeleteValidations(Guid id)
        {
            if (id == Guid.Empty)
                throw new Exception("Id não informado.");

            var exist = EventRepository.Exists(x => x.Id == id);
            if (!exist)
                throw new Exception("Registro não encontrado.");
        }

        public IEnumerable<EventViewModel> List()
        {
            var entity = EventRepository.List();
            var viewModel = Mapper.Map<IEnumerable<EventViewModel>>(entity);
            return viewModel;
        }

        public IEnumerable<DashboardViewModel> Dashboard()
        {
            var result = EventRepository.Dashboard();
            return result;
        }
    }
}
