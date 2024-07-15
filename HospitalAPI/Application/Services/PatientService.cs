using AutoMapper;
using HospitalAPI.Application.DTO.Patient;
using HospitalAPI.Application.Interfaces;
using HospitalAPI.Domain.Entities;
using HospitalAPI.Domain.Interfaces;
using HospitalAPI.Infrastructure.Persistence;

namespace HospitalAPI.Application.Services 
{ 
    public class PatientService: IPatientService 
    { 
        private readonly IPatientDomain _patientDomain; 
        private readonly IMapper _mapper; 
        private readonly DataContext _context; 
        public PatientService(IPatientDomain patientDomain, IMapper mapper, DataContext dataContext) 
        { 
            _patientDomain = patientDomain; 
            _mapper = mapper; 
            _context = dataContext; 
        }

        public async Task<bool> Add(PatientCreateDto patients)
        {
            try
            {
                await _patientDomain.Add(_mapper.Map<Patients>(patients));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write("Patient not Create", ex);
                return false;
            }
        }

        public async Task<bool> Delete(int Id)
        {
            try
            {
                await _patientDomain.Delete(Id);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write("Patient not Create", ex);
                return false;
            }
        }

        public async Task<List<PatientListDto>> GetAll()
        {
            try
            {
                return _mapper.Map<List<PatientListDto>>(await _patientDomain.GetAll());
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public async Task<PatientListDto> GetById(int Id)
        {
            try
            {
                return _mapper.Map<PatientListDto>(await _patientDomain.GetById(Id));
            }
            catch (Exception ex)
            {
                throw new Exception("ERROR", ex);
            }
        }

        public async Task<bool> Update(PatientUpdateDto patients)
        {
            try
            {
                await _patientDomain.Update(_mapper.Map<Patients>(patients));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
    } 
} 
