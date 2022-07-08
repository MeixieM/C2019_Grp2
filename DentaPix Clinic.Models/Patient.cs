using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DentaPix_Clinic.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [ValidateNever]
        [Display(Name = "Profile Picture")]
        public string ImageURL { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Middle Initial is required")]
        public string MiddleInitial { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{MM/dd/yyyy}")]
        public DateTime Birthday { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Mobile Number is required")]
        public string PhoneNo { get; set; }

        public string Email { get; set; }
        public string Gender { get; set; }
        public string Parent { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{MM/dd/yyyy}")]
        public DateTime RegisteredDate { get; set; } = DateTime.Now;

        //Relationships

        //Treatment
        //public int TreatmentId { get; set; }
        //[ForeignKey("TreatmentId")]
        //[ValidateNever]
        //public Treatment Treatment { get; set; }

        //Payment
        //public int PaymentId { get; set; }
        //[ForeignKey("PaymentId")]
        //[ValidateNever]
        //public Payment Payment { get; set; }

        //Doctor
        //public int DoctorId { get; set; }
        //[ForeignKey("DoctorId")]
        //[ValidateNever]

        //public Doctor Doctor { get; set; }
    }
}