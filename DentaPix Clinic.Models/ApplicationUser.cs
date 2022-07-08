using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentaPix_Clinic.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string? Address { get; set; }

        public int? DoctorId { get; set; }

        [ForeignKey("DoctorId")]
        [ValidateNever]
        public Doctor Doctor { get; set; }
    }
}