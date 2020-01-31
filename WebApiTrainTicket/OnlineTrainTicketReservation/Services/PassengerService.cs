using OnlineTrainTicketReservation.Services;
using OnlineTrainTicketReservation.Models;
using OnlineTrainTicketReservation.Repository;
using System;
using System.Collections.Generic;

namespace OnlineTrainTicketReservation.Services
{
    public class PassengerService : IPassengerService
    {
        private readonly IDatabaseRepo repo;
        public PassengerService(IDatabaseRepo repo)
        {
            this.repo = repo;
        }

        public bool DeletePassenger(int passenger_id)
        {   // if the passenger has booked a ticket, do not delete it
            bool result = repo.HasPassengerReservedATicket(passenger_id);

            if (result)
                throw new ApplicationException("Cannot delete passenger! Passenger has booked a ticket!");

            Passenger passenger = repo.GetPassenger(passenger_id);

            // if passenger does not exist in the db, return true as if it was deleted
            if (passenger == null)
                return true;

            return repo.DeletePassenger(passenger_id);
        }

        public bool AddPassenger(Passenger passenger)
        {
            if (passenger == null) return false;

            return repo.AddPassenger(passenger);
        }

        public bool UpdatePassenger(int passenger_id, Passenger passenger)
        {
            if (passenger == null) return false;

            var foundPassenger = repo.GetPassenger(passenger_id);

            if (foundPassenger == null)
                throw new ApplicationException("Passenger does not exist!");

            return repo.UpdatePassenger(passenger_id, passenger);
        }

        public IEnumerable<Passenger> GetPassengers()
        {
            var passengers = repo.GetPassengers();
            if (passengers != null)
            {
                foreach (var passenger in passengers)
                {
                    passenger.BookTicket = repo.GetReservedTicketByPassengerId(passenger.passenger_id);
                }
            }
            return passengers;
        }

        public Passenger GetPassenger(int passenger_id)
        {
            var passenger = repo.GetPassenger(passenger_id);

            // get the reservation that the passenger has booked
            if (passenger != null) passenger.BookTicket = repo.GetReservedTicketByPassengerId(passenger.passenger_id);

            return passenger;
        }

        bool BookTicket(int ticket_id, int passenger_id, Reservation reservation)
        {
            // check if passenger exists
            var passenger = repo.GetPassenger(passenger_id);

            if (passenger == null)
                throw new System.ApplicationException("Passenger does not exist!");

            // check if train exists
            var train = repo.GetTrains();

            if (train == null)
                throw new System.ApplicationException("Train does not exist!");

            return repo.BookTicket(ticket_id, passenger_id, reservation);
        }

        bool IPassengerService.BookTicket(int ticket_id, int passenger_id, Reservation reservation)
        {
            throw new NotImplementedException();
        }
    }
}
