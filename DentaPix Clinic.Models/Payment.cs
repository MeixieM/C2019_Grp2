using DentaPix_Clinic.Data.Enums;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;


namespace DentaPix_Clinic.Models
{
    public class Payment
    {
        [Key]
        [ValidateNever]
        public int PaymentId { get; set; }

        public DateTime Date { get; set; }

        public PaymentStatus PaymentStatus { get; set; }
        public string Method { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public double Payments { get; set; }
        public double Balance { get; set; }
        //public int PatientId { get; set; }
        //Relationships
        public List<Patient> Patients { get; set; }

    }
}
