using Domain.Model.Entity;
using Domain.Model.ViewModel;
using AutoMapper;
using Domain.Model.Payload;
using Infra.Helpers;

namespace Domain.Service.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Event, EventViewModel>().ReverseMap();
            CreateMap<Event, EventPayload>().ReverseMap();

            CreateMap<Guest, GuestViewModel>().ReverseMap();
            CreateMap<Guest, GuestPayload>().ReverseMap();

            CreateMap<Event, EventViewModel>().ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => (
                    src.DateTime.ConvertToDateString()
                )));
        }
    }
}
