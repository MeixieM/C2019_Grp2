using Microsoft.AspNetCore.Mvc.Rendering;

namespace DentaPix_Clinic.Models.ViewModels
{
    public class PatientVM
    {
        public Patient Patient { get; set; }
        public IEnumerable<SelectListItem> DoctorList { get; set; }
        public IEnumerable<SelectListItem> AppointmentList { get; set; }


    }
}
