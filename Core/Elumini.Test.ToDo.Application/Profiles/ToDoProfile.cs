using AutoMapper;
using Elumini.Test.ToDo.Application.Ports.Dtos;

namespace Elumini.Test.ToDo.Application.Profiles
{
    public class ToDoProfile : Profile
    {
        public ToDoProfile()
        {
            CreateMap<Domain.ToDo, ToDoDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.DtConclusion, opt => opt.MapFrom(src => src.DtConclusion))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.DtCreated, opt => opt.MapFrom(src => src.DtCreated))
                .ReverseMap();

            CreateMap<Domain.ToDo, ToDoCreateDto>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.DtConclusion, opt => opt.MapFrom(src => src.DtConclusion))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.DtCreated, opt => opt.MapFrom(src => src.DtCreated))
                .ReverseMap();

            CreateMap<Domain.ToDo, ToDoUpdateDto>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.DtConclusion, opt => opt.MapFrom(src => src.DtConclusion))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.DtCreated, opt => opt.MapFrom(src => src.DtCreated))
                .ReverseMap();

        }
    }
}
