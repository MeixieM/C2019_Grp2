using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentaPix_Clinic.Models
{
    public class Overview
    {
        [Key]
        public int OverviewId { get; set; }


        //Relationships

        //Patient
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        [ValidateNever]
        public Patient Patient { get; set; }

        //Treatment
        public int TreatmentId { get; set; }
        [ForeignKey("TreatmentId")]
        [ValidateNever]
        public Treatment Treatment { get; set; }



        //Doctor
        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        [ValidateNever]

        public Doctor Doctor { get; set; }


        //Appointment
        public int AppointmentId { get; set; }
        [ForeignKey("AppointmentId")]
        [ValidateNever]

        public Appointment Appointment { get; set; }






    }
}
