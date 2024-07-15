using AutoMapper;
using HospitalAPI.Application.DTO.Generic;
using HospitalAPI.Application.DTO.Patient;
using HospitalAPI.Domain.Entities;

namespace HospitalAPI.Application.Mapper
{
    public class GlobalMapper: Profile
    {
        public GlobalMapper()
        {
            CreateMap<PatientCreateDto, Patients>();
            CreateMap<PatientUpdateDto, Patients>();
            CreateMap<Patients, PatientListDto>()
              .ForMember(dest => dest.DocumentTypeDescription, opt => opt.MapFrom(src => src.documentTypeNavigation.Description))
              .ForMember(dest => dest.GenderDescription, opt => opt.MapFrom(src => src.GenderNavigation.Description));

            CreateMap<DocumentType, GenericModelDto>();
            CreateMap<Gender, GenericModelDto>();
        }
    }
}
