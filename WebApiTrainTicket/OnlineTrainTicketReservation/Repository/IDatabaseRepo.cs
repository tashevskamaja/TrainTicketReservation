using OnlineTrainTicketReservation.Models;
using System.Collections.Generic;

namespace OnlineTrainTicketReservation.Repository
{
    public interface IDatabaseRepo
    {
       bool DeletePassenger(int passenger_id);
       bool AddPassenger(Passenger passenger);
       bool UpdatePassenger(int passenger_id, Passenger passenger);
       List<Passenger> GetPassengers();
       Passenger GetPassenger(int passenger_id);
       bool UpdateNoOfPassengers(int passenger_id, Passenger passenger);
       bool UpdateArrivalTime(int train_id, Train train);
       bool UpdateDepartureTime(int train_id, Train train);
       bool UpdateAvailabilityOfSeats(int train_id, Train train);
       bool AddTrain(Train train);
       Train GetTrain(int train_id);
        List<Train> GetTrains();
        bool BookTicket(int ticket_id, int passenger_id, Reservation reservation);
        bool HasPassengerReservedATicket(int passenger_id);
        List<Train> GetReservedTicketByPassengerId(int passenger_id);
        UserLogin GetUser(string username, string password);










    }
}
