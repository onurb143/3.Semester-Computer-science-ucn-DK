using RESTfulService.BusinessLogicLayer;
using RESTfulService.DTOs;
using Microsoft.AspNetCore.Mvc;
using DatabaseData.ModelLayer;
using Microsoft.AspNetCore.Authorization;

namespace RESTfulService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderdata _businessLogicCtrl;
        private readonly IFlightdata _flightDataCtrl;
        private readonly ICustomerdata _customerDataCtrl;

        // Constructor with Dependency Injection
        public OrdersController(IOrderdata inBusinessLogicCtrl, IFlightdata inFlightDataCtrl, ICustomerdata inCustomerDataCtrl)
        {
            _businessLogicCtrl = inBusinessLogicCtrl;
            _flightDataCtrl = inFlightDataCtrl;
            _customerDataCtrl = inCustomerDataCtrl;
        }


        // URL: api/Orders
        [Authorize]
        [HttpGet("protected")]
        public IActionResult ProtectedEndpoint()
        {
            return Ok(new { result = "Du har adgang til beskyttet data!" });
        }
        [HttpGet] // Endpoints are now /api/Orders (default route)
        public ActionResult<List<OrderDto>> Get()

        {
            ActionResult<List<OrderDto>> foundReturn;
            // retrieve data - converted to DTO
            List<OrderDto>? foundOrders = _businessLogicCtrl.Get();
            // evaluate
            if (foundOrders != null)
            {
                if (foundOrders.Count > 0)
                {
                    foundReturn = Ok(foundOrders);                 // Statuscode 200
                }
                else
                {
                    foundReturn = new StatusCodeResult(204);    // Ok, but no content
                }
            }
            else
            {
                foundReturn = new StatusCodeResult(500);        // Internal server error
            }
            return foundReturn;
        }

        // URL: api/Orders
        [HttpPost]
        public ActionResult<Order> CreateOrder(OrderDto inOrderDto)
        {
            // Tjek for null input
            if (inOrderDto == null)
            {
                return BadRequest("Order data is required.");
            }

            try
            {
                OrderDto createdOrderDto = _businessLogicCtrl.CreateOrder(inOrderDto);

                if (createdOrderDto != null && createdOrderDto.OrderID > 0) 
                {
                    return Ok(createdOrderDto.OrderID); // Returnerer ID'et for den nyoprettede ordre
                }
                else
                {
                    return Conflict("The flight is already booked."); // Flighten er allerede booket
                }
            }
            catch (Exception ex)
            {
                // Håndter fejl og returner en fejlstatuskode
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        // URL: api/Orders
        [HttpPut("Update")] // Endpoints are now /api/Orders/Update
        public ActionResult<OrderDto> UpdateOrder([FromBody] OrderDto order)

        {
            OrderDto updatedOrder = _businessLogicCtrl.Put(order);
            if (updatedOrder != null)
            {
                return Ok(updatedOrder); // Statuscode 200
            }
            else
            {
                return StatusCode(500); // Internal server error
            }
        }

    }
}