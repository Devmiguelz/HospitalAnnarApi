using HospitalAPI.Application.DTO.Patient;
using HospitalAPI.Application.Interfaces;
using HospitalAPI.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace HospitalAPI.Controllers 
{ 
    [Route("api/[controller]")] 
    [ApiController] 
    public class PatientController : ControllerBase 
    { 
        private readonly IPatientService _patientService; 
        public PatientController(IPatientService patientService) 
        { 
            _patientService = patientService; 
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<List<PatientListDto>>> GetAll()
        {
            var patientList = await _patientService.GetAll();
            return Ok(patientList);
        }

        [HttpGet("[action]/{id:int}")]
        public async Task<ActionResult<PatientListDto>> GetById(int id)
        {
            var patient = await _patientService.GetById(id);
            if (patient is null)
            {
                return NotFound();
            }
            return Ok(patient);
        }

        [HttpDelete("[action]/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _patientService.Delete(id);
            if (!deleted)
            {
                return BadRequest("Patient Not Deleted.");
            }
            return Ok(true);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<bool>> Add(PatientCreateDto patient)
        {
            var created = await _patientService.Add(patient);
            if (!created)
            {
                return BadRequest("Patient Not Created.");
            }
            return Ok(true);
        }

        [HttpPut("[action]")]
        public async Task<ActionResult<bool>> Update(PatientUpdateDto patient)
        {
            var updated = await _patientService.Update(patient);
            if(!updated)
            {
                return BadRequest("Patient Not Updated.");
            }
            return Ok(true);
        }
    } 
} 
