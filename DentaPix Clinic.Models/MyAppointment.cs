using System.ComponentModel.DataAnnotations;

namespace DentaPix_Clinic.Models
{
    public class MyAppointment
    {
        public Appointment Appointment { get; set; }
        [Range(1, 1, ErrorMessage = "Sorry But you can only book one appointment at a time")]
        public int Count { get; set; }
    }
}
