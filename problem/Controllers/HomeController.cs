using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataLayer.DatabaseContext;
using Entities.Entitiler;
using Entities.DTO;
using Entities.DTO.Response;
using LT.Customer.Business;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace problem.Controllers
{
    [ApiController]
    [Route("Customers")]
    public class HomeController : Controller
    {
        private readonly CustomerDbContext context2;
   

        public HomeController(CustomerDbContext context)
        {
            this.context2 = context;
        }

       
        
    
        [HttpGet]
        public async Task<IEnumerable<Customers>> Get()
        {
            return await context2.Customers.ToListAsync();
        }

        [HttpGet]
        [Route("LimitedGet")]
        public async Task<ActionResult<List<LimitedGetResponse>>> LimitedGet()
        {
           CustomerBusiness response = new CustomerBusiness(context2);

           return response.LimitedGetFunction();  
        }

        [HttpGet("GetById")]
        [ProducesResponseType(typeof(Customers), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await context2.Customers.FindAsync(id);
            return customer == null ? NotFound() : Ok(customer);
        }

        [HttpPost]
        [Route("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer(CustomerDto customerDto)
        {
            await context2.Customers.AddAsync(customerDto.customers);
            await context2.SaveChangesAsync();

            customerDto.customerAdresses.customer_ID = customerDto.customers.customer_ID;

            await context2.CustomerAdresses.AddAsync(customerDto.customerAdresses);
            await context2.SaveChangesAsync();

            customerDto.customerDepartment.customer_ID = customerDto.customers.customer_ID;

            await context2.CustomerDepartment.AddAsync(customerDto.customerDepartment);
            await context2.SaveChangesAsync();
            return Ok(true);
        }

        [HttpPut]
        [Route("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(CustomerDto customerDto)
        {
            context2.Entry(customerDto).State = EntityState.Modified;
            await context2.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customerToDelete = await context2.Customers.FindAsync(id);
            var customerAdressToDelete = await context2.CustomerAdresses.FirstOrDefaultAsync(x => x.customer_ID == id);
            var customerDepartmentToDelete = await context2.CustomerDepartment.FirstOrDefaultAsync(x => x.customer_ID == id);

            if (customerToDelete == null && customerAdressToDelete == null && customerDepartmentToDelete == null)
                return NotFound();

            if(customerAdressToDelete != null)
            {
                context2.CustomerAdresses.Remove(customerAdressToDelete);
                await context2.SaveChangesAsync();
            }
           if(customerDepartmentToDelete != null)
            {
                context2.CustomerDepartment.Remove(customerDepartmentToDelete);
                await context2.SaveChangesAsync();
            }
           if(customerToDelete != null)
            {
                context2.Customers.Remove(customerToDelete);
                await context2.SaveChangesAsync();
            }

            return NoContent();
        } 

    }
}

 