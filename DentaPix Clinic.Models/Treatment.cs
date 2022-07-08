using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DentaPix_Clinic.Models
{
    public class Treatment
    {
        [Key]
        public int TreatmentId { get; set; }

        [ValidateNever]
        [Required(ErrorMessage = "Please Insert Image")]
        public string Image { get; set; }

        public string Name { get; set; }
        public string? Description { get; set; }

        [Range(1, 10000000, ErrorMessage = "Price must be greater than 0!")]
        public double TreatmentPrice { get; set; }

        [ValidateNever]
        public List<Patient> Patients { get; set; }
    }
}