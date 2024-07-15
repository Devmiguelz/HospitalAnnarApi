using HospitalAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Infrastructure.Persistence
{
    public class DataContext: DbContext
    {
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration): base(options)
        {
            
        }

        public virtual DbSet<Gender> Gender {  get; set; }
        public virtual DbSet<DocumentType> DocumentType {  get; set; }
        public virtual DbSet<Patients> Patient {  get; set; }

    }
}
