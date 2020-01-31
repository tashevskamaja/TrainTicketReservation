using OnlineTrainTicketReservation.Models;
using OnlineTrainTicketReservation.Validation;
using OnlineTrainTicketReservation.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiTrainTicket.Controllers
{
    //[AllowAnonymous]
    [Authorize(Roles = "Admin")]
    public class PassengerController : ApiController
    {
        private readonly IPassengerService service;

        public PassengerController(IPassengerService serivce)
        {
            this.service = service;
        }

        // GET api/passengers
        public IEnumerable<Passenger> Get()
        {
            return service.GetPassengers();
        }

        // GET api/passengers/5
        public IHttpActionResult Get(int passenger_id)
        {
            var passenger = this.service.GetPassenger(passenger_id);

            if (passenger == null)
            {
                return NotFound();
            }
            return base.Ok(passenger);
        }

        public object BookTicket(int v, int ticket_id)
        {
            throw new NotImplementedException();
        }

        // POST api/passengers
        //[AllowAnnonymous]
        public HttpResponseMessage Post(Passenger passenger)
        {
            Passenger_Validation validator = new Passenger_Validation();
            var result = validator.Validate(passenger);

            if (!result.IsValid) return Request.CreateResponse(HttpStatusCode.BadRequest, result.Errors);

            if (service.AddPassenger(passenger))
                return Request.CreateResponse(HttpStatusCode.Created);
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
                               
        }

        // PUT api/passengers/5
        public IHttpActionResult Put(int passenger_id, Passenger passenger)
        {
            Passenger_Validation validator = new Passenger_Validation();
            var result = validator.Validate(passenger);

            if (!result.IsValid) return BadRequest();

            try
            {
                if (service.UpdatePassenger(passenger_id, passenger))
                {
                    return Ok();
                }
                return InternalServerError();
            }
            catch(ApplicationException ex)
            {
                return NotFound();
            }
        }
        
        // DELETE api/passengers/5
        public HttpResponseMessage Delete(int passenger_id)
        {
            try
            {
                if (service.DeletePassenger(passenger_id))
                    return Request.CreateResponse(HttpStatusCode.NoContent);
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            catch (ApplicationException ex)
            {
                return Request.CreateResponse(HttpStatusCode.Forbidden, ex.Message);
            }
        }

        [Route("api/passengers/{passengerId}/book/{bookId}")]
        [HttpPost]
        public HttpResponseMessage BookTicket(int ticket_id, int passenger_id, Reservation reservation)
        {
            try
            {
                var result = service.BookTicket(ticket_id, passenger_id, reservation);
                if (result)
                    return Request.CreateResponse(HttpStatusCode.OK);
                else
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Failed to book a ticket!");
             }
            catch(ApplicationException ex)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
             }
        }
           
    }
}