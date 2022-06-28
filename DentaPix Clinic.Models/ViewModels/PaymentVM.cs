using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DentaPix_Clinic.Models.ViewModels
{
    public class PaymentVM
    {
        public Payment Payment { get; set; }
        [ValidateNever]

        public IEnumerable<SelectListItem> PatientList { get; set; }
        [ValidateNever]

        public IEnumerable<SelectListItem> TreatmentList { get; set; }



    }
}
