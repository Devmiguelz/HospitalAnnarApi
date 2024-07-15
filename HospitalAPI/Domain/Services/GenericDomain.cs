using HospitalAPI.Domain.Entities;
using HospitalAPI.Domain.Interfaces;
using HospitalAPI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Domain.Services 
{ 
   public class GenericDomain: IGenericDomain 
   { 
       private readonly DataContext _context; 
       public GenericDomain(DataContext dataContext) 
       { 
           _context = dataContext;  
       }

        public async Task<IEnumerable<DocumentType>> GetDocumentTypes()
        {
            return await _context.DocumentType.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Gender>> GetGender()
        {
            return await _context.Gender.AsNoTracking().ToListAsync();
        }
    } 
} 
