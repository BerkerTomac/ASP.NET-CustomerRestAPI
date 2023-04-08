using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Entitiler
{
    public class CustomerDepartment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Required]
        public int departmentID { get; set; }
        public string departmentName { get; set; }
        [Required]
        public int yearsOfExperience { get; set; }
        [ForeignKey("Customers")]
        public int customer_ID { get; set; }
    }
}

