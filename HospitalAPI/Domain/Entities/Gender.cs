using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAPI.Domain.Entities
{
    public class Gender
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }

        public virtual ICollection<Patients> PatientsNavigation { get; set; }
    }
}
