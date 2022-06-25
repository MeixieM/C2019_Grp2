using DentaPix_Clinic.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace DentaPix_Clinic.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]

        public string LastName { get; set; }
        [Required]
        [Display(Name = "Email")]

        public string Email { get; set; }
        [Required]
        [Display(Name = "Mobile Number")]

        public string MobileNo { get; set; }

        [Required(ErrorMessage = "Please set date and time ")]

        [Display(Name = "Appointment Date and Time")]
        public DateTime AppointmentDate { get; set; }
        [Required]


        public string? NatureOfAppointment { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{MM/dd/yyyy}")]
        public DateTime Birthday { get; set; }
        public string? Message { get; set; }
        public DateTime RegisteredDate { get; set; } = DateTime.Now;

        public AppointmentStatus AppointmentStatus { get; set; }

        //Relationships

        //Doctor
        //[Display(Name = "Doctor")]
        //[ForeignKey("DoctorId")]
        //public int DoctorId { get; set; }
        //[ValidateNever]

        //public Doctor Doctor { get; set; }

        //[ForeignKey("PatientId")]
        //public int PatientId { get; set; }
        //[ValidateNever]

        //public Patient Patient { get; set; }


    }
}
