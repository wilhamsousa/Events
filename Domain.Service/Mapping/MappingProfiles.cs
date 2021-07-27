using Domain.Model.Entity;
using Domain.Model.ViewModel;
using AutoMapper;
using Domain.Model.Payload;

namespace Domain.Service.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Event, EventViewModel>().ReverseMap();
            CreateMap<Event, EventPayload>().ReverseMap();
        }
    }
}
