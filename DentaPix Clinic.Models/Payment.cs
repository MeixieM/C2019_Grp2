using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentaPix_Clinic.Models
{
    public class Payment
    {
        [Key]
        [ValidateNever]
        public int PaymentId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{MM/dd/yyyy}")]
        public DateTime Date { get; set; }

        public string? Method { get; set; }

        [Display(Name = "Service Description")]
        public string? Description { get; set; }

        public double? Amount { get; set; }

        [Display(Name = "Payments/Adjustments")]
        public double? Payments { get; set; }

        [Display(Name = "Patient Balance")]
        public double? Balance { get; set; }

        public string? PaymentStatus { get; set; }

        //Relationships
        [Required]
        [Display(Name = "Patient Name")]
        public int PatientId { get; set; }

        [ForeignKey("PatientId")]
        [ValidateNever]
        public Patient Patient { get; set; }

        //Treatment
        [Required]
        [Display(Name = "Treatments")]
        public int TreatmentId { get; set; }

        [ForeignKey("TreatmentId")]
        [ValidateNever]
        public Treatment Treatment { get; set; }
    }
}