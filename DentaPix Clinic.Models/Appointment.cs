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

        public DateTime AppointmentDate { get; set; }
        public DayOfWeek AppointmentDay { get; set; }
        public string Description { get; set; }
        public string AppointmentStatus { get; set; }

        //Relationships
        public List<Patient_Appointment> Patients_Appointments { get; set; }


    }
}
