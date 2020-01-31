using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineTrainTicketReservation.Models;

namespace OnlineTrainTicketReservation.Validation
{
    public class Passenger_Validation : AbstractValidator<Passenger>
    {
        public Passenger_Validation()
        {
            RuleFor(x => x.first_name).NotEmpty().WithMessage("First name is required.");
            RuleFor(x => x.last_name).NotEmpty().WithMessage("Last name is required.");
            RuleFor(x => x.gender).NotEmpty().WithMessage("Gender is required.");
            RuleFor(x => x.age).NotEmpty().WithMessage("Age is required.");

            RuleFor(x => x.gender).Length(1).WithMessage("Gender must be one charachter.");
            RuleFor(x => x.gender).Must(Validate_Gender).WithMessage("Gender must be one charachter of the specified.");
        }
        
        private bool Validate_Gender(string gender)
        {
            List<string> validValues = new List<string>
            {
                "F",
                "M"
            };
            return validValues.Contains(gender);
        }

    }
}
