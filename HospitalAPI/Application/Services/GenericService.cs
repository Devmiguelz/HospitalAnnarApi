using AutoMapper;
using HospitalAPI.Application.DTO.Generic;
using HospitalAPI.Application.Interfaces;
using HospitalAPI.Domain.Interfaces;
using HospitalAPI.Infrastructure.Persistence;

namespace HospitalAPI.Application.Services 
{ 
    public class GenericService: IGenericService 
    { 
        private readonly IGenericDomain _genericDomain; 
        private readonly IMapper _mapper; 
        private readonly DataContext _context; 
        public GenericService(IGenericDomain genericDomain, IMapper mapper, DataContext dataContext) 
        { 
            _genericDomain = genericDomain; 
            _mapper = mapper; 
            _context = dataContext; 
        }

        public async Task<IEnumerable<GenericModelDto>> GetDocumentTypes()
        {
            try
            {
                return _mapper.Map<IEnumerable<GenericModelDto>>(await _genericDomain.GetDocumentTypes());
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        public async Task<IEnumerable<GenericModelDto>> GetGender()
        {
            try
            {
                return _mapper.Map<IEnumerable<GenericModelDto>>(await _genericDomain.GetGender());
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex); 
            }
        }
    } 
} 
