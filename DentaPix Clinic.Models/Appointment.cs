using System.ComponentModel.DataAnnotations;

namespace DentaPix_Clinic.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmendId { get; set; }
        public int AppointmentNo { get; set; }
        //public int DoctorId { get; set; }
        //public int PatientId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }
        [Required]

        public string Email { get; set; }
        [Required]

        public string MobileNo { get; set; }
        [Required]

        public DateTime AppointmentDate { get; set; }
        [Required]

        public string NatureOfAppointment { get; set; }

        public DateTime Birthday { get; set; }

        public string Message { get; set; }
        public DateTime RegisteredDate { get; set; } = DateTime.Now;

        //public string AppointmentStatus { get; set; }

        //Relationships
        public List<Patient_Appointment> Patients_Appointments { get; set; }


    }
}
