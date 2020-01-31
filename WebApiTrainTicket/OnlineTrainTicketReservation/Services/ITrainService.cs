using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineTrainTicketReservation.Models;


namespace OnlineTrainTicketReservation.Services
{
    public interface ITrainService
    {
        bool AddTrain(Train value);
        Train GetTrain(int train_id);
        List<Train> GetTrains();
        bool UpdateArrivalTime(int train_id, Train train);
        bool UpdateDepartureTime(int train_id, Train train);
        bool UpdateAvailabilityOfSeats(int train_id, Train train);

    }
}
