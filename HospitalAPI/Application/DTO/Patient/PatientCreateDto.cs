namespace HospitalAPI.Application.DTO.Patient
{
    public class PatientCreateDto
    {
        public int DocumentTypeId { get; set; }
        public string DocumentNumber { get; set; }
        public int GenderId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirhtDate { get; set; }
        public string? Address { get; set; }
        public string? ContactNumber { get; set; }
    }
}
