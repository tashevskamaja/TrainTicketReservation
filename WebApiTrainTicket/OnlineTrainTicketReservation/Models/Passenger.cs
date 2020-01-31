using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTrainTicketReservation.Models
{
    public class Passenger
    {
        [JsonProperty("passenger_id")]
        public int passenger_id { get; set; }

        [JsonProperty ("first_name")]
        public string first_name { get; set; }

        [JsonProperty("last_name")]
        public string last_name { get; set; }

        [JsonProperty("gender")]
        public string gender { get; set; }

        [JsonProperty("age")]
        public int age { get; set; }

        [JsonProperty("city")]
        public string city { get; set; }

        [JsonProperty("reservation_status")]
        public string reservation_status { get; set; }

        [JsonProperty("seat_number")]
        public int seat_number { get; set; }

        [JsonProperty("no_of_passengers")]
        public int no_of_passengers { get; set; }

        public List<Train> BookTicket { get; set; }

    }
}
