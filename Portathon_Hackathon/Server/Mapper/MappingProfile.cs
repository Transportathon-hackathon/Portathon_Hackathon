﻿using AutoMapper;
using Portathon_Hackathon.Shared.DTO;
using Portathon_Hackathon.Shared.Entities;

namespace Portathon_Hackathon.Server.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Company, CompanyDTO>().ReverseMap();
            CreateMap<Vehicle, VehicleDTO>().ReverseMap();
            CreateMap<CrewMember, CrewMemberDTO>().ReverseMap();
            CreateMap<Request, RequestDTO>().ReverseMap();
            CreateMap<Reservation, ReservationDTO>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Evaluation, EvaluationDTO>().ReverseMap();
            CreateMap<Message, MessageDTO>().ReverseMap();
            CreateMap<Reservation, ReservationReturnDTO>()
                .ForMember(dest => dest.User, src => src.MapFrom(opt => opt.Request.User)).ReverseMap();
            CreateMap<Vehicle, VehicleReturnDTO>()
                 .ForMember(dest => dest.CompanyName, src => src.MapFrom(opt => opt.Company.CompanyName));
        }
    }
}
