using Application;
using Application.Interface;
using Domain.Service;
using Domain.Service.Interface;
using Infra.Repository;
using Infra.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace BigBrain.Corujinha.API
{
    public static class ServicesInject
    {
        public static void Execute(IServiceCollection services)
        {
            #region Application
            services.AddTransient(typeof(IEventApplication), typeof(EventApplication));
            services.AddTransient(typeof(IGuestApplication), typeof(GuestApplication));
            
            #endregion

            #region Service
            services.AddTransient(typeof(IEventService), typeof(EventService));
            services.AddTransient(typeof(IGuestService), typeof(GuestService));
            #endregion

            #region Infra
            services.AddTransient(typeof(IEventRepository), typeof(EventRepository));
            services.AddTransient(typeof(IGuestRepository), typeof(GuestRepository));
            #endregion
        }
    }
}
