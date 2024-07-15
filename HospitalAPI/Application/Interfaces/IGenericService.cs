using HospitalAPI.Application.DTO.Generic;
using HospitalAPI.Domain.Entities;

namespace HospitalAPI.Application.Interfaces 
{ 
    public interface IGenericService 
    {
        Task<IEnumerable<GenericModelDto>> GetDocumentTypes();
        Task<IEnumerable<GenericModelDto>> GetGender();
    } 
}  
