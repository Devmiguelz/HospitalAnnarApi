using HospitalAPI.Application.DTO.Generic;
using HospitalAPI.Application.DTO.Patient;
using HospitalAPI.Application.Interfaces;
using HospitalAPI.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers 
{ 
    [Route("api/[controller]")] 
    [ApiController] 
    public class GenericController : ControllerBase 
    { 
        private readonly IGenericService _genericService; 
        public GenericController(IGenericService genericService) 
        { 
            _genericService = genericService; 
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<GenericModelDto>>> GetDocumentType()
        {
            return Ok(await _genericService.GetDocumentTypes());
        }

        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<GenericModelDto>>> GetGender()
        {
            return Ok(await _genericService.GetGender());
        }
    } 
} 
