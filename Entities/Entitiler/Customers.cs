using System;
using System.ComponentModel.DataAnnotations;

namespace Entities.Entitiler
{
    public class Customers
    {
        [Key]
        [Required]
        public int customer_ID { get; set; }
        [Required]
        public string customer_name { get; set; }
        [Required]
        public string customer_surname { get; set; }
        public string? customer_email_adress { get; set; }
        [Required]
        public string customer_company { get; set; }
        public string? customer_job_title { get; set; }
        [Required]
        public string customer_registiration_date { get; set; }
    }
}

