using System.ComponentModel.DataAnnotations;

namespace DentaPix_Clinic.Data.Enums
{
    public enum AppointmentStatus
    {
        Booked = 1,
        Completed,
        [Display(Name = "In Process")]
        InProcess,
        Canceled

    }
}
