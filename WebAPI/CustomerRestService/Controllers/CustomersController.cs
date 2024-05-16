using RESTfulService.BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;
using RESTfulService.DTOs;

namespace RESTfulService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerdata _businessLogicCtrl;

        public CustomersController(ICustomerdata inBusinessLogicCtrl)
        {
            _businessLogicCtrl = inBusinessLogicCtrl;
        }

        // URL: api/customers?email=value
        [HttpGet]
        public ActionResult<List<CustomerDto>> Get([FromQuery] string? email)
        {
            List<CustomerDto> foundCustomerDtos = _businessLogicCtrl.Get(email);
            if (foundCustomerDtos != null && foundCustomerDtos.Count > 0)
            {
                return Ok(foundCustomerDtos); // Statuscode 200
            }
            else if (foundCustomerDtos != null)
            {
                return NoContent(); // Statuscode 204 - Ok, but no content
            }
            else
            {
                return StatusCode(500); // Internal server error
            }
        }

        // URL: api/customers/{loginid}
        [HttpGet("{loginid}")]
        public ActionResult<CustomerDto?> GetByLoginId(string loginid)
        {
            CustomerDto foundCustomer = _businessLogicCtrl.GetByUserId(loginid);
            if (foundCustomer != null)
            {
                return Ok(foundCustomer); // Statuscode 200
            }
            else
            {
                return StatusCode(500); // Internal server error
            }
        }

        // URL: api/customers
        [HttpPost]
        public ActionResult<CustomerDto> CreateNewCustomer(CustomerDto inCustomer)
        {
            var createdCustomer = _businessLogicCtrl.CreateNewCustomer(inCustomer);
            if (createdCustomer != null)
            {
                return Ok(createdCustomer);
            }

            else
            {
                return StatusCode(500); // Internal server error
            }
        }

        // URL: api/customers/{loginid}
        [HttpPut("{loginid}")]
        public ActionResult<CustomerDto> UpdateCustomer(CustomerDto customer)
        {
            CustomerDto updatedCustomer = _businessLogicCtrl.Put(customer);
            if (updatedCustomer != null)
            {
                return Ok(updatedCustomer); // Statuscode 200
            }
            else
            {
                return StatusCode(500); // Internal server error
            }
        }
    }
}
