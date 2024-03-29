﻿using Application.Interface;
using Domain.Model.InputModel;
using Domain.Model.ViewModel;
using Domain.Service.Interface;
using System;
using System.Collections.Generic;

namespace Application
{
    public class GuestApplication : IGuestApplication
    {
        private readonly IGuestService GuestService;

        public GuestApplication(IGuestService guestService, IServiceProvider serviceProvider)
        {
            GuestService = guestService;
        }

        public Domain.Model.ViewModel.Guest Create(Domain.Model.InputModel.Guest payload)
        {
            var result = GuestService.Create(payload);
            return result;
        }

        public void Update(Guid id, Domain.Model.InputModel.Guest payload)
        {
            GuestService.Update(id, payload);
        }

        public Domain.Model.ViewModel.Guest Read(Guid id)
        {
            var result = GuestService.Read(id);
            return result;
        }

        public void Delete(Guid id)
        {
            GuestService.Delete(id);
        }

        public IEnumerable<Domain.Model.ViewModel.Guest> List()
        {
            var result = GuestService.List();
            return result;
        }
    }
}
