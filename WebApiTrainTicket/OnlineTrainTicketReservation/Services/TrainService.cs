using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineTrainTicketReservation.Models;
using OnlineTrainTicketReservation.Repository;

namespace OnlineTrainTicketReservation.Services
{
    public class TrainService : ITrainService
    {
        private readonly IDatabaseRepo repo;
        public TrainService(IDatabaseRepo repo)
        {
            this.repo = repo;
        }

        public bool AddTrain(Train train)
        {
            if (train == null) return false;
            return repo.AddTrain(train);
        }

        public Train GetTrain(int train_id)
        {
            return repo.GetTrain(train_id);
        }


        public List<Train> GetTrains()
        {
            return repo.GetTrains();
        }

        public bool UpdateArrivalTime(int train_id, Train train)
        {
            Train foundTrain = repo.GetTrain(train_id);

            if (foundTrain == null)
                throw new ApplicationException("Train does not exist!");

            return repo.UpdateArrivalTime(train_id, train);
        }


        public bool UpdateDepartureTime(int train_id, Train train)
        {
            Train foundTrain = repo.GetTrain(train_id);

            if (foundTrain == null)
                throw new ApplicationException("Train does not exist!");

            return repo.UpdateDepartureTime(train_id, train);
        }

        public bool UpdateAvailabilityOfSeats(int train_id, Train train)

        {
            Train foundTrain = repo.GetTrain(train_id);

            if (foundTrain == null)
                throw new ApplicationException("Train does not exist!");

            return repo.UpdateAvailabilityOfSeats(train_id, train);
        }

    }   }

