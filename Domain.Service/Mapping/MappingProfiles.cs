using Domain.Model.Entity;
using Domain.Model.ViewModel;
using AutoMapper;
using Domain.Model.InputModel;
using Infra.Helpers;

namespace Domain.Service.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Model.Entity.Event, Model.ViewModel.Event>().ReverseMap();
            CreateMap<Model.Entity.Event, Model.InputModel.Event>().ReverseMap();

            CreateMap<Model.Entity.Guest, Model.ViewModel.Guest>().ReverseMap();
            CreateMap<Model.Entity.Guest, Model.InputModel.Guest>().ReverseMap();

            CreateMap<Model.Entity.Event, Model.ViewModel.Event>().ForMember(dest => dest.DateTime, opt => opt.MapFrom(src => (
                    src.DateTime.ConvertToDateString()
                )));
        }
    }
}
