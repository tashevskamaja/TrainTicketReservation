using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineTrainTicketReservation.Models;

namespace OnlineTrainTicketReservation.Validation
{
    public class Train_Validation : AbstractValidator<Train>
    {
        public Train_Validation()
        {
            RuleFor(x => x.train_name).NotEmpty().WithMessage("Train name is required.");
            RuleFor(x => x.departure_time).NotEmpty().WithMessage("Departure time is required.");
            RuleFor(x => x.arrival_time).NotEmpty().WithMessage("Arrival time is required.");
            RuleFor(x => x.availability_of_seats).NotEmpty().WithMessage("Availability of seats is required.");
            RuleFor(x => x.date).NotEmpty().WithMessage("Date is required.");
        }
    }
}
