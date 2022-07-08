using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DentaPix_Clinic.Models.ViewModels
{
    public class PatientVM
    {
        public Patient Patient { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> DoctorList { get; set; }

        //[ValidateNever]
        //public IEnumerable<SelectListItem> AppointmentList { get; set; }
    }
}