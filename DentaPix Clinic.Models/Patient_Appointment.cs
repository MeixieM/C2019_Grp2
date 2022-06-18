namespace DentaPix_Clinic.Models
{
    public class Patient_Appointment
    {
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int AppointmentId { get; set; }
        public Appointment Appointment { get; set; }


    }
}
