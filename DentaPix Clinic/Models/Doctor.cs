using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DentaPix_Clinic.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        [DisplayName("Profile Picture URL")]
        public string ProfilePictureURL { get; set; }
        [Required]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [DisplayName("Career")]
        public string Career { get; set; }

        [DisplayName("Interest")]
        public string Interest { get; set; }

        public List<Patient> Patients { get; set; }

    }
}
