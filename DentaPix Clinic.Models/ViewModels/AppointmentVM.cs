using Microsoft.AspNetCore.Mvc.Rendering;

namespace DentaPix_Clinic.Models.ViewModels
{
    public class AppointmentVM
    {
        public Appointment Appointment { get; set; }
        public IEnumerable<SelectListItem> DoctorList { get; set; }
        public IEnumerable<SelectListItem> PatientList { get; set; }
    }
}