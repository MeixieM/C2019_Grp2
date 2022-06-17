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

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }

        public DateTime AppointmentDate { get; set; }
        public string NatureOfAppointment { get; set; }
        public DateTime Birthday { get; set; }

        public string Message { get; set; }
        //public string AppointmentStatus { get; set; }

        //Relationships
        public List<Patient_Appointment> Patients_Appointments { get; set; }


    }
}
