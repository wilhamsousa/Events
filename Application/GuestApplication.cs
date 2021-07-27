using Application.Interface;
using Domain.Model.Payload;
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

        public GuestViewModel Create(GuestPayload payload)
        {
            var result = GuestService.Create(payload);
            return result;
        }

        public void Update(Guid id, GuestPayload payload)
        {
            GuestService.Update(id, payload);
        }

        public GuestViewModel Read(Guid id)
        {
            var result = GuestService.Read(id);
            return result;
        }

        public void Delete(Guid id)
        {
            GuestService.Delete(id);
        }

        public IEnumerable<GuestViewModel> List()
        {
            var result = GuestService.List();
            return result;
        }
    }
}
