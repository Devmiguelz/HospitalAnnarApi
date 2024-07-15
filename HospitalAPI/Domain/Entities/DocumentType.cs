using System.ComponentModel.DataAnnotations;

namespace HospitalAPI.Domain.Entities
{
    public class DocumentType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }

        public virtual ICollection<Patients> PatientsNavigation { get; set; }
    }
}
