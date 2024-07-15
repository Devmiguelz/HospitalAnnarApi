using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAPI.Domain.Entities
{
    public class Patients
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int DocumentTypeId { get; set; }

        [Required]
        public int DocumentNumber { get; set; }

        [Required]
        public int GenderId { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "Date")]
        public DateTime BirhtDate { get; set; }

        [Column(TypeName = "varchar(200)")]
        public string? Address { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string? ContactNumber { get; set; }

        public bool Active { get; set; }

        public virtual Gender GenderNavigation { get; set; }
        public virtual DocumentType documentTypeNavigation { get; set; }
    }
}
