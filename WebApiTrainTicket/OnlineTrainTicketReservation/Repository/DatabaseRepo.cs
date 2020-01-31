using Dapper;
using OnlineTrainTicketReservation.Models;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using OnlineTrainTicketReservation.DbHelper;


namespace OnlineTrainTicketReservation.Repository
{
    public class DatabaseRepo : IDatabaseRepo
    {
        ILog logger;

        public DatabaseRepo(ILog logger)
        {
            this.logger = logger;
        }

        public bool DeletePassenger(int passenger_id)
        {
            logger.Info("Deleting passenger " + passenger_id);
            try
            {
                using (SqlConnection conn = DBAccess.GetOpenConnection())
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@passenger_id", passenger_id);

                    int result = conn.Execute("spDeletePassenger", parameter, commandType: CommandType.StoredProcedure);

                    return result > 0;
                }
            }
            catch (Exception e)
            {
                logger.Error("Error happened while deleting the passenger! " + e.Message, e);
                return false;
            }
        }

        public bool AddPassenger(Passenger passenger)
        {
            try
            {
                using (SqlConnection conn = DBAccess.GetOpenConnection())
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@first_name", passenger.first_name);
                    parameter.Add("@last_name", passenger.last_name);
                    parameter.Add("@gender", passenger.gender);
                    parameter.Add("@age", passenger.age);
                    parameter.Add("@city", passenger.city);
                    parameter.Add("@reservation_status", passenger.reservation_status);
                    parameter.Add("@seat_number", passenger.seat_number);

                    int result = conn.Execute("spInsertPassenger", parameter, commandType: CommandType.StoredProcedure);
                    return result > 0;
                }
            }
            catch (Exception e)
            {
                logger.Error("Error happened while adding the passenger! " + e.Message, e);
                return false;
            }
        }

        public bool UpdatePassenger(int passenger_id, Passenger passenger)
        {
            try
            {
                using (SqlConnection conn = DBAccess.GetOpenConnection())
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@first_name", passenger.first_name);
                    parameter.Add("@last_name", passenger.last_name);
                    parameter.Add("@reservation_status", passenger.reservation_status);
                    parameter.Add("@seat_number", passenger.seat_number);

                    int result = conn.Execute("spUpdatePassenger", parameter, commandType: CommandType.StoredProcedure);
                    return result > 0;
                }
            }
            catch (Exception e)
            {
                logger.Error("Error happened while updating the passenger! " + e.Message, e);
                return false;
            }
        }

        public List<Passenger> GetPassengers()
        {
            try
            {
                using (SqlConnection conn = DBAccess.GetOpenConnection())
                {
                    List<Passenger> result = conn.Query<Passenger>("spGetAllPassengers", commandType: CommandType.StoredProcedure).ToList();
                    return result;
                }
            }
            catch (Exception e)
            {
                logger.Error("Error happened while getting the passengers! " + e.Message, e);
                return null;
            }
        }

        public Passenger GetPassenger(int passenger_id)
        {
            try
            {
                using (SqlConnection conn = DBAccess.GetOpenConnection())
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@passenger_id", passenger_id);

                    Passenger result = conn.Query<Passenger>("spGetPassenger", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception e)
            {
                logger.Error("Error happened while getting the passenger! " + e.Message, e);
                return null;
            }
        }

        public bool UpdateNoOfPassengers(int passenger_id, Passenger passenger)
        {
            try
            {
                using (SqlConnection conn = DBAccess.GetOpenConnection())
                {
                    DynamicParameters parameter = new DynamicParameters();

                    parameter.Add("@no_of_passengers", passenger.no_of_passengers);

                    int result = conn.Execute("spUpdateNoOfPassengers", parameter, commandType: CommandType.StoredProcedure);
                    return result > 0;
                }
            }
            catch (Exception e)
            {
                logger.Error("Error happened while updating the number of passengers! " + e.Message, e);
                return false;
            }
        }
        public bool UpdateArrivalTime(int train_id, Train train)
        {
            try
            {
                using (SqlConnection conn = DBAccess.GetOpenConnection())
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@train_id", train_id);
                    parameter.Add("@arrival_time", train.arrival_time);
                    parameter.Add("@date", train.date);

                    int result = conn.Execute("spUpdateArrivalTime", parameter, commandType: CommandType.StoredProcedure);
                    return result > 0;
                }
            }
            catch (Exception e)
            {
                logger.Error("Error happened while updating the arrival time! " + e.Message, e);
                return false;
            }
        }

        public bool UpdateDepartureTime(int train_id, Train train)
        {
            try
            {
                using (SqlConnection conn = DBAccess.GetOpenConnection())
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@train_id", train.train_id);
                    parameter.Add("@departure_time", train.departure_time);
                    parameter.Add("@date", train.date);

                    int result = conn.Execute("spUpdateDepartureTime", parameter, commandType: CommandType.StoredProcedure);
                    return result > 0;
                }
            }
            catch (Exception e)
            {
                logger.Error("Error happened while updating departure time !" + e.Message, e);
                return false;
            }
        }

        public bool UpdateAvailabilityOfSeats(int train_id, Train train)
        {
            try
            {
                using (SqlConnection conn = DBAccess.GetOpenConnection())
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@train_id", train.train_id);
                    parameter.Add("@train_name", train.train_name);
                    parameter.Add("@date", train.date);
                    parameter.Add("@availability_of_seats", train.availability_of_seats);

                    int result = conn.Execute("spUpdateAvailabilityOfSeats", parameter, commandType: CommandType.StoredProcedure);
                    return result > 0;
                }
            }
            catch (Exception e)
            {
                logger.Error("Error happened while updating availability of seats! " + e.Message, e);
                return false;
            }
        }

        public bool AddTrain (Train train)
        {
            try
            {
                using (SqlConnection conn = DBAccess.GetOpenConnection())
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@train_name", train.train_name);
                    parameter.Add("@arrival_time", train.arrival_time);
                    parameter.Add("@departure_time", train.departure_time);
                    parameter.Add("@availability_of_seats", train.availability_of_seats);
                    parameter.Add("@date", train.date);

                    int result = conn.Execute("spInsertTrain", parameter, commandType: CommandType.StoredProcedure);

                    return result > 0;                         
                }
            }
            catch (Exception e)
            {
                logger.Error("Error happened while adding the book! " + e.Message, e);
                return false;
            }
        }


        public Train GetTrain(int train_id)
        {
            try
            {
                using (SqlConnection conn = DBAccess.GetOpenConnection())
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@train_id", train_id);

                    Train result = conn.Query<Train>("spGetTrain", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception e )
            {
                logger.Error("Error happened while getting the train! " + e.Message, e);
                return null;
            }
        }

               
        public List<Train> GetTrains()
        {
            try
            {
                using (SqlConnection conn = DBAccess.GetOpenConnection())
                {
                                      
                    List<Train> result = conn.Query<Train>("spGetAllTrains", commandType: CommandType.StoredProcedure).ToList();
                    return result;
                }
            }
            catch (Exception e)
            {
                logger.Error("Error happened while getting the trains! " + e.Message, e);
                return null;
            }
        }

        public bool BookTicket(int ticket_id, int passenger_id, Reservation reservation)
        {
            try
            {
                using (SqlConnection conn = DBAccess.GetOpenConnection())
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@ticket_id", ticket_id);
                    parameter.Add("@passenger_id", passenger_id);
                    parameter.Add("@status", reservation.status);
                    parameter.Add("@seat_number", reservation.seat_number);

                    int result = conn.Execute("spReserveTicket", parameter, commandType: CommandType.StoredProcedure);
                    return result > 0;
                }
            }

            catch (Exception e)
            {
                logger.Error("Error happened while reserving the ticket! " + e.Message, e);
                return false;
            }
        }

        public bool HasPassengerReservedATicket(int passenger_id)
        {
            try
            {
                using (SqlConnection conn = DBAccess.GetOpenConnection())
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@passenger_id", passenger_id);

                    List<int> ticketIds = conn.Query<int>("spHasPassengerReservedATicket", parameter, commandType: CommandType.StoredProcedure).ToList();
                    return ticketIds.Any();
                }
            }
            catch (Exception e)
            {
                logger.Error("Error happened while checking if passenger has reserved a ticket! " + e.Message, e);
                return false;
            }
        }

        public List<Train> GetReservedTicketByPassengerId(int passenger_id)
        {
            try
            {
                using (SqlConnection conn = DBAccess.GetOpenConnection())
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@passenger_id", passenger_id);

                    List<Train> trains = conn.Query<Train>("spGetReservedTicketByPassengerId", parameter, commandType: CommandType.StoredProcedure).ToList();
                    return trains;
                }
            }
            catch (Exception e)
            {
                logger.Error("Error happened while getting the ticket! " + e.Message, e);
                return null;
            }
        }
        public UserLogin GetUser(string username, string password)
        {
            try
            {
                using (SqlConnection conn = DBAccess.GetOpenConnection())
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@username", username);
                    parameter.Add("@password", password);

                    UserLogin result = conn.Query<UserLogin>("spUserLogin", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    return result;
                }
            }
            catch (Exception e)
            {
                logger.Error("Error happened while logging in! " + e.Message, e);
                return null;
            }
        }
    }
}


