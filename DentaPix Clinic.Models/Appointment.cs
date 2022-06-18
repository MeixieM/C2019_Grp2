using DentaPix_Clinic.Data.Enums;
using DentaPix_Clinic.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Appointment
{
    [Key]
    public int AppointmendId { get; set; }
    [Range(1, 1000, ErrorMessage = "Appointment Number must be greater than 1!")]
    public int AppointmentNo { get; set; }
    //public int DoctorId { get; set; }
    //public int PatientId { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]

    public string LastName { get; set; }
    [Required]

    public string Email { get; set; }
    [Required]

    public string MobileNo { get; set; }
    [Required]
    public DateTime AppointmentDate { get; set; }
    [Required]

    public string NatureOfAppointment { get; set; }


    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{MM/dd/yyyy}")]
    public DateTime Birthday { get; set; }

    public string Message { get; set; }
    public DateTime RegisteredDate { get; set; } = DateTime.Now;

    public AppointmentStatus AppointmentStatus { get; set; }

    //Relationships
    public List<Patient_Appointment> Patients_Appointments { get; set; }
    //Doctor
    public int DoctorId { get; set; }
    [ForeignKey("DoctorId")]
    public Doctor Doctor { get; set; }


}
