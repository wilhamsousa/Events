﻿using AutoMapper;
using Domain.Model.Entity;
using Domain.Model.Payload;
using Domain.Model.ViewModel;
using Domain.Service.Interface;
using Infra.Repository.Interface;
using System;
using System.Collections.Generic;

namespace Domain.Service
{

    public class GuestService : IGuestService
    {
        private readonly IGuestRepository GuestRepository;
        private readonly IMapper Mapper;
        private readonly IServiceProvider ServiceProvider;

        public GuestService(IServiceProvider serviceProvider, IMapper mapper, IGuestRepository guestRepository)
        {
            GuestRepository = guestRepository;
            Mapper = mapper;
            ServiceProvider = serviceProvider;
        }

        public GuestViewModel Create(GuestPayload payload)
        {
            CreateValidations(payload);
            var newEntity = Mapper.Map<Guest>(payload);
            var entity = GuestRepository.Create(newEntity);
            var viewModel = Mapper.Map<GuestViewModel>(entity);
            return viewModel;
        }

        private void CreateValidations(GuestPayload payload)
        {
            if (string.IsNullOrEmpty(payload.Name))
                throw new Exception("Nome não informado.");

            if (payload.Payment != null && payload.Payment < 0)
                throw new Exception("Valor de pagamento inválido.");

            var exist = GuestRepository.Exists(x => x.EventId == payload.EventId && x.Name == payload.Name);
            if (exist)
                throw new Exception("Este convidado já existe.");

            var eventRepository = (IEventRepository)ServiceProvider.GetService(typeof(IEventRepository));
            exist = eventRepository.Exists(x => x.Id == payload.EventId);
            if (!exist)
                throw new Exception("Evento não encontrado.");
        }

        public GuestViewModel Read(Guid id)
        {
            ReadValidations(id);
            var entity = GuestRepository.Read(id);
            var viewModel = Mapper.Map<GuestViewModel>(entity);
            return viewModel;
        }

        private void ReadValidations(Guid id)
        {
            if (id == Guid.Empty)
                throw new Exception("Id não informado.");
        }

        public void Update(Guid id, GuestPayload payload)
        {
            UpdateValidations(id, payload);
            var newEntity = Mapper.Map<Guest>(payload);
            newEntity.Id = id;
            GuestRepository.Update(newEntity);
        }

        private void UpdateValidations(Guid id, GuestPayload payload)
        {
            if (id == Guid.Empty)
                throw new Exception("Id não informado.");

            if (string.IsNullOrEmpty(payload.Name))
                throw new Exception("Nome não informado.");

            if (payload.Payment != null && payload.Payment < 0)
                throw new Exception("Valor de pagamento inválido.");

            var exist = GuestRepository.Exists(x => x.Id == id);
            if (!exist)
                throw new Exception("Registro não encontrado.");

            var eventRepository = (IEventRepository)ServiceProvider.GetService(typeof(IEventRepository));
            exist = eventRepository.Exists(x => x.Id == payload.EventId);
            if (!exist)
                throw new Exception("Evento não encontrado.");
        }

        public void Delete(Guid id)
        {
            DeleteValidations(id);
            GuestRepository.Delete(id);
        }

        private void DeleteValidations(Guid id)
        {
            if (id == Guid.Empty)
                throw new Exception("Id não informado.");

            var exist = GuestRepository.Exists(x => x.Id == id);
            if (!exist)
                throw new Exception("Registro não encontrado.");
        }

        public IEnumerable<GuestViewModel> List()
        {
            var entity = GuestRepository.List();
            var viewModel = Mapper.Map<IEnumerable<GuestViewModel>>(entity);
            return viewModel;
        }
    }
}
