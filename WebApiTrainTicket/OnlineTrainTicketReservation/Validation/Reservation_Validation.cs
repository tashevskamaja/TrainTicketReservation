using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineTrainTicketReservation.Models;

namespace OnlineTrainTicketReservation.Validation
{
    public class Reservation_Validation : AbstractValidator<Reservation>
    {
     public Reservation_Validation()
        {
            RuleFor(x => x.status).NotEmpty().WithMessage("Status is required.");
            RuleFor(x => x.seat_number).NotEmpty().WithMessage("Seat number is required.");

            RuleFor(x => x.status).Must(Validate_Status).WithMessage("Status must be one of the specified! Confirmed or cancelled!");
        }

        private bool Validate_Status(string status)
        {
            List<string> validValues = new List<string>
            {
                "Confirmed",
                "Cancelled"
            };

            return validValues.Contains(status);
        }
    }
}
