using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTrainTicketReservation.Models
{
    public class Train
    {
        [JsonProperty("train_id")]
        public int train_id { get; set; }

        [JsonProperty("train_name")]
        public int train_name { get; set; }

        [JsonProperty("arrival_time")]
        public int arrival_time { get; set; }

        [JsonProperty("departure_time")]
        public int departure_time { get; set; }

        [JsonProperty("availability_of_seats")]
        public int availability_of_seats { get; set; }

        [JsonProperty("date")]
        public int date { get; set; }
    }
}
