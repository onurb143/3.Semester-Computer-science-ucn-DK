using RESTfulService.BusinessLogicLayer;
using RESTfulService.DTOs;
using Microsoft.AspNetCore.Mvc;
using DatabaseData.ModelLayer;

namespace RESTfulService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {

        private readonly IFlightdata _businessLogicCtrl;


        // Constructor with Dependency Injection
        public FlightsController(IFlightdata inBusinessLogicCtrl)
        {
            _businessLogicCtrl = inBusinessLogicCtrl;
        }

        // URL: api/Flights
        [HttpGet]
        public ActionResult<List<FlightDto>> GetAllFlights()
        {
            ActionResult<List<FlightDto>> foundReturn;
            // retrieve data - converted to DTO
            List<FlightDto>? foundFlights = _businessLogicCtrl.Get();
            // evaluate
            if (foundFlights != null)
            {
                if (foundFlights.Count > 0)
                {
                    foundReturn = Ok(foundFlights);                 // Statuscode 200
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
            // send response back to client
            return foundReturn;
        }

        // URL: api/Flights/{id}
        [HttpGet, Route("{id}")]
        public ActionResult<FlightDto> Get(int id)
        {
            ActionResult<FlightDto> foundReturn;
            // retrieve data - converted to DTO
            FlightDto? foundFlights = _businessLogicCtrl.GetFlightById(id);
            // evaluate
            if (foundFlights != null)
            {
                foundReturn = Ok(foundFlights);                 // Statuscode 200
            }
            else
            {
                foundReturn = new StatusCodeResult(500);        // Internal server error
            }
            // send response back to client
            return foundReturn;
        }

        // URL: api/Flights
        [HttpPost]
        public ActionResult<FlightDto> PostNewFlight(FlightDto inFlightDto)
        {
            ActionResult<FlightDto> foundReturn;
            FlightDto insertedFlight = _businessLogicCtrl.Add(inFlightDto);
            // Evaluate
            if (insertedFlight != null) {
                foundReturn = Ok(insertedFlight);
            }
            else
            {
                foundReturn = new StatusCodeResult(500);    // Internal server error
            }
            return foundReturn;
        }


      

    }

}



