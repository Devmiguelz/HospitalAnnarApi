using HospitalAPI.Application.DTO.Patient;

namespace HospitalAPI.Application.Interfaces 
{ 
    public interface IPatientService 
    {
        Task<bool> Add(PatientCreateDto patients);
        Task<bool> Update(PatientUpdateDto patients);
        Task<bool> Delete(int Id);
        Task<PatientListDto> GetById(int Id);
        Task<List<PatientListDto>> GetAll();
    } 
}  
