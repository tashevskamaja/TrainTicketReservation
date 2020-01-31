using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineTrainTicketReservation.Models;

namespace OnlineTrainTicketReservation.Services
{
    public interface IPassengerService
    {
        bool DeletePassenger(int passenger_id);
        bool AddPassenger(Passenger value);
        bool UpdatePassenger(int passenger_id, Passenger value);
        IEnumerable<Passenger> GetPassengers();
        Passenger GetPassenger(int passenger_id);
        bool BookTicket(int ticket_id, int passenger_id, Reservation reservation);
       
    }
}
