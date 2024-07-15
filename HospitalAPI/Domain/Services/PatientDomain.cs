using HospitalAPI.Domain.Entities;
using HospitalAPI.Domain.Interfaces;
using HospitalAPI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Domain.Services 
{ 
   public class PatientDomain: IPatientDomain 
   { 
       private readonly DataContext _context; 
       public PatientDomain(DataContext dataContext) 
       { 
           _context = dataContext;  
       }

        public async Task Add(Patients patients)
        {
            patients.Active = true;
            await _context.Patient.AddAsync(patients);
        }

        public async Task Delete(int Id)
        {
            var patientExist = await _context.Patient.FindAsync(Id);
            if (patientExist is null)
            {
                throw new Exception("Patient Not Found");
            }
            patientExist.Active = false;
        }

        public async Task<List<Patients>> GetAll()
        {
            return await _context.Patient.AsNoTracking().Include(x => x.GenderNavigation).Include(x => x.documentTypeNavigation).Where(x => x.Active).ToListAsync();
        }

        public async Task<Patients> GetById(int Id)
        {
            var patientExist = await _context.Patient.Include(x => x.GenderNavigation).Include(x => x.documentTypeNavigation).FirstOrDefaultAsync(x => x.Id.Equals(Id));
            if (patientExist is null)
            {
                throw new Exception("Patient Not Found");
            }
            return patientExist;
        }

        public async Task Update(Patients patients)
        {
            var patientExist = await _context.Patient.FindAsync(patients.Id);
            if (patientExist is null)
            {
                throw new Exception("Patient Not Found");
            }
            patients.Active = true;
            _context.Entry(patientExist).CurrentValues.SetValues(patients);
        }
    } 
} 
