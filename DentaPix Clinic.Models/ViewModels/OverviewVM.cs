using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DentaPix_Clinic.Models.ViewModels
{
    public class OverviewVM
    {
        public Overview Overview { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> DoctorList { get; set; }
        [ValidateNever]

        public IEnumerable<SelectListItem> PatientList { get; set; }
        [ValidateNever]

        public IEnumerable<SelectListItem> TreatmentList { get; set; }
        [ValidateNever]

        public IEnumerable<SelectListItem> AppointmentList { get; set; }

        public int patientTotal { get; set; }


    }
}
