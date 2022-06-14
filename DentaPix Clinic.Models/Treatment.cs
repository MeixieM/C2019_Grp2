﻿using System.ComponentModel.DataAnnotations;

namespace DentaPix_Clinic.Models
{
    public class Treatment
    {
        [Key]
        public int TreatmentId { get; set; }
        public string ImageURL { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Patient> Patients { get; set; }


    }
}