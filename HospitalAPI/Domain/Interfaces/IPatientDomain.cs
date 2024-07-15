using HospitalAPI.Domain.Entities;

namespace HospitalAPI.Domain.Interfaces 
{ 
    public interface IPatientDomain 
    {
        Task Add(Patients patients);
        Task Update(Patients patients);
        Task Delete(int Id);
        Task<Patients> GetById(int Id);
        Task<List<Patients>> GetAll();
    } 
} 
