using System;
using DataLayer.DatabaseContext;
using Entities.DTO.Response;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.DTO;

namespace LT.Customer.Business


{
    public class CustomerBusiness
    {
        private readonly CustomerDbContext context;



        public CustomerBusiness(CustomerDbContext context)
        {
            this.context = context;
        }

        public List<LimitedGetResponse> LimitedGetFunction()
        {
            try
            {
                var test1 = (from c in context.Customers
                             join e in context.CustomerAdresses
                                 on c.customer_ID equals e.customer_ID
                             select new LimitedGetResponse
                             {
                                 customerName = c.customer_name,
                                 customerSurname = c.customer_surname,
                                 emailAdress = c.customer_email_adress,
                                 phoneNumber = e.phone_number

                             }).ToList();

                return test1;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
}
}
