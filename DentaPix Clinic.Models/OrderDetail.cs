
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentaPix_Clinic.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        [Required]
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        [ValidateNever]
        public OrderHeader OrderHeader { get; set; }

        [Required]
        public int TreatmentId { get; set; }
        [ForeignKey("TreatmentId")]
        [ValidateNever]
        public Treatment Treatment { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }

    }
}
