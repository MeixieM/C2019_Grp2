using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentaPix_Clinic.Models
{
    public class AppointmentCart
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        [ForeignKey("AppointmentId")]
        [ValidateNever]
        public Appointment Appointment { get; set; }
        [Range(1, 1, ErrorMessage = "Sorry But you can only book one appointment at a time")]
        public int Count { get; set; }

        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
