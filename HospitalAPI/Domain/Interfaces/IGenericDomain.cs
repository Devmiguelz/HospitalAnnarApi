using HospitalAPI.Domain.Entities;

namespace HospitalAPI.Domain.Interfaces 
{ 
    public interface IGenericDomain 
    {
        Task<IEnumerable<DocumentType>> GetDocumentTypes();
        Task<IEnumerable<Gender>> GetGender();
    } 
} 
