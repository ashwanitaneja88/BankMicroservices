using CustomerApi;
using customersApi;
using Helpers;
using Microsoft.AspNetCore.Mvc;

namespace BankMicroservices.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly ICustomerRepository _customerRepository;

        public CustomersController(ILogger<CustomersController> logger, ICustomerRepository customerRepository)
        {
            _logger = logger;
            _customerRepository = customerRepository;
        }

        [HttpPost("Post")]
        public IActionResult Post(Customer customer)
        {
            if (!Helper.ValidateCustomer(customer.email))
            {
                return BadRequest("email is not allowed");
            }
            return Ok(_customerRepository.SaveCustomers(customer));
        }

        [HttpGet("Get")]
        public IActionResult Get() => Ok(_customerRepository.GetCustomers());

        [HttpGet("GetCustomerByEmail")]
        public IActionResult GetCustomer(string email) => Ok(_customerRepository.GetCustomer(email));

        [HttpPut("Put")]
        public IActionResult UpdateCustomer(string email, Customer customer)
        {
            if (!Helper.ValidateCustomer(customer.email))
            {
                return BadRequest("email is not allowed");
            }
            if (email.ToLower() != customer.email.ToLower())
            {
                return BadRequest();
            }
            return Ok(_customerRepository.UpdateCustomer(customer));
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(String email)
        {
            if (!Helper.ValidateCustomer(email))
            {
                return BadRequest("email is not allowed");
            }
            return Ok(_customerRepository.DeleteCustomer(email));
        }

    }
}