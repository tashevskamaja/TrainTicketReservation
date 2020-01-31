using OnlineTrainTicketReservation.Models;
using OnlineTrainTicketReservation.Repository;
using OnlineTrainTicketReservation.Services;

namespace OnlineTrainTicketReservation.Services
{
    public class UserService : IUserService
    {
        private IDatabaseRepo repo;

        public UserService(IDatabaseRepo repo)
        {
            this.repo = repo;
        }

        public UserLogin ValidateLogin(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)) return null;

            return repo.GetUser(username, password);
               
        }
    }
}
