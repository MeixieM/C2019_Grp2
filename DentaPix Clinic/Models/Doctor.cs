using System.ComponentModel.DataAnnotations;

namespace DentaPix_Clinic.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }
        [Display(Name = "Profile Picture URL")]
        public string ProfilePictureURL { get; set; }
        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Career")]
        public string Career { get; set; }

        [Display(Name = "Interest")]
        public string Interest { get; set; }

        //public List<Patient> Patients { get; set; }

    }
}
