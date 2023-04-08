using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entitiler
{
    public class CustomerAdresses
    {
        [Key]
        [Required]
        public int customerAdresses_ID { get; set; }
        [ForeignKey("Customers")]
        public int customer_ID { get; set; }
        public string? country { get; set; }
        public string? city { get; set; }
        [Required]
        public string primary_adress { get; set; }
        public string? secondary_adress { get; set; }
        public string? third_adress { get; set; }
        [Required]
        public int phone_number { get; set; }
    }
}

