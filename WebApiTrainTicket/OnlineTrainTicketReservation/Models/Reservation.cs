using Newtonsoft.Json;

namespace OnlineTrainTicketReservation.Models
{
    public class Reservation
    {
        [JsonProperty("book_id")]
        public int book_id { get; set; }

        [JsonProperty("user_id")]
        public int user_id { get; set; }

        [JsonProperty("passenger_id")]
        public int passenger_id { get; set; }

        [JsonProperty("ticket_id")]
        public int ticket_id { get; set; }

        [JsonProperty("status")]
        public string status { get; set; }

        [JsonProperty("seat_number")]
        public int seat_number { get; set; }
    }
}
