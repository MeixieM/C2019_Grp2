using System.ComponentModel.DataAnnotations;

namespace DentaPix_Clinic.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        public string ProfilePictureURL { get; set; }
        public string FullName { get; set; }
        public string Career { get; set; }
        public string Interest { get; set; }

        public List<Patient> Patients { get; set; }

    }
}
