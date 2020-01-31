using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OnlineTrainTicketReservation.Models;
using OnlineTrainTicketReservation.Validation;
using OnlineTrainTicketReservation.Services;

namespace WebApiTrainTicket.Controllers
{
    public class TrainController : ApiController
    {
        private readonly ITrainService service;

        public TrainController(ITrainService service)
        {
            this.service = service;
        }

        // GET api/trains
        public IEnumerable<Train> Get()
        {
            return service.GetTrains();
        }

        // GET api/trains/5
        public IHttpActionResult Get(int train_id)
        {
            var train = service.GetTrain(train_id);
            if (train == null)
            {
                return NotFound();
            }
            return Ok(train);
        }

        // POST api/trains
        public HttpResponseMessage Post(Train train)
        {
            Train_Validation validator = new Train_Validation();
            var result = validator.Validate(train);

            if (!result.IsValid) return Request.CreateResponse(HttpStatusCode.BadRequest);

            if (service.AddTrain(train))
                return Request.CreateResponse(HttpStatusCode.Created);
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }

        // PUT api/trains/5
        public IHttpActionResult Put(int train_id, Train train)
        {
            Train_Validation validator = new Train_Validation();
            var result = validator.Validate(train);

            if (!result.IsValid) return BadRequest();

            try
            {
                if (service.UpdateAvailabilityOfSeats(train_id, train))
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
    }
}