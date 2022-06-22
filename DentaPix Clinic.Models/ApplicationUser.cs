using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DentaPix_Clinic.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]

        public string LastName { get; set; }

        public string? Address { get; set; }

    }
}
