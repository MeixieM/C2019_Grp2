using System.ComponentModel.DataAnnotations;


namespace DentaPix_Clinic.Models
{
    public class Payment
    {
        [Key]
        public int PaymentId { get; set; }

        public DateTime Date { get; set; }

        //public PaymentStatus PaymentStatus { get; set; }
        public string Method { get; set; }
        public string Notes { get; set; }
        public double Amount { get; set; }
        //public string Balance { get; set; }
        //public int PatientId { get; set; }
        //Relationships
        public List<Patient> Patients { get; set; }

    }
}
