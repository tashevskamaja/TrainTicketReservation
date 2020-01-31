using OnlineTrainTicketReservation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTrainTicketReservation.Services
{
    public interface IUserService
    {
        UserLogin ValidateLogin(string username, string password);
    }
}
