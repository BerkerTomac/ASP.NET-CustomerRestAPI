using System;
using Entities.Entitiler;

namespace Entities.DTO
{
    public class CustomerDto
    {
        public Customers customers { get; set; }
        public CustomerDepartment customerDepartment { get; set; }
        public CustomerAdresses customerAdresses { get; set; }
    }
}

