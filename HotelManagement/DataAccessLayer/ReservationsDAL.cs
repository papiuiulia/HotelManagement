using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class ReservationsDAL
    {
        private const string _connectionString = "Server=IULIA-NOTEBOOK\\MSSQLSERVER2017;Database=master;Trusted_Connection=True;";
        private const string RESERVATIONS_READ_ALL = "dbo.Reservations_ReadAll";
        private const string RESERVATIONS_READ_BY_GUID = "dbo.Reservations_ReadByGUID";
        private const string RESERVATIONS_UPDATE = "dbo.Reservations_UpdateByID";
        private const string RESERVATIONS_TYPE_INSERT = "dbo.Reservations_InsertByID";
        private const string RESERVATIONS_DELETE_BY_GUID = "dbo.Reservations_DeleteByID";

        public List<Reservation> ReadAll()
        {
            List<Reservation> reservations = new List<Reservation>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = RESERVATIONS_READ_ALL;
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Reservation reservation = ConvertToModel(dataReader);
                            reservations.Add(reservation);
                        }
                    }
                }
            }

            return reservations;
        }

        public Reservation ReadByUid(Guid reservationUid)
        {
            Reservation reservation = new Reservation();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = RESERVATIONS_READ_BY_GUID;
                    command.Parameters.Add(new SqlParameter("@ID", reservationUid));
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            reservation = ConvertToModel(dataReader);
                        }
                    }
                }
            }

            return reservation;
        }

        public void UpdateById(Reservations reservations)
        {
            using (SqlConnnection connection = new SqlConnnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.ComandType.StoredProcedure;
                    command.CommandText = RESERVATIONS_UPDATE_BY_GUID;
                    command.Parameters.Add(new SqlParameter("@ID", reservations.ID));
                    command.Parameters.Add(new SqlParameter("@DateCreation", reservations.DateCreation));
                    command.Parameters.Add(new SqlParameter("@CheckIn", reservations.CheckIn));
                    command.Parameters.Add(new SqlParameter("@CheckOut", reservations.CheckOut));
                    command.Parameters.Add(new SqlParameter("@NumberOfAdults", reservations.NumberOfAdults));
                    command.Parameters.Add(new SqlParameter("@NumberOfChildren", reservations.NumberOfChildren));
                    command.Parameters.Add(new SqlParameter("@Meal", reservations.Meal));
                    command.Parameters.Add(new SqlParameter("@ReservationTypeID", reservations.ReservationTypeID));
                    command.Parameters.Add(new SqlParameter("@GuestID", reservations.GuestID));
                    command.Parameters.Add(new SqlParameter("@RoomID", reservations.RoomID));
                    command.ExecuteReader();
                }
            }
        }


        public void InsertById(Reservations reservations)
        {
            using (SqlConnnection connection = new SqlConnnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.ComandType.StoredProcedure;
                    command.CommandText = RESERVATIONS_INSERT_BY_GUID;
                    command.Parameters.Add(new SqlParameter("@ID", reservations.ID));
                    command.Parameters.Add(new SqlParameter("@DateCreation", reservations.DateCreation));
                    command.Parameters.Add(new SqlParameter("@CheckIn", reservations.CheckIn));
                    command.Parameters.Add(new SqlParameter("@CheckOut", reservations.CheckOut));
                    command.Parameters.Add(new SqlParameter("@NumberOfAdults", reservations.NumberOfAdults));
                    command.Parameters.Add(new SqlParameter("@NumberOfChildren", reservations.NumberOfChildren));
                    command.Parameters.Add(new SqlParameter("@Meal", reservations.Meal));
                    command.Parameters.Add(new SqlParameter("@ReservationTypeID", reservations.ReservationTypeID));
                    command.Parameters.Add(new SqlParameter("@GuestID", reservations.GuestID));
                    command.Parameters.Add(new SqlParameter("@RoomID", reservations.RoomID));
                    command.ExecuteReader();
                }

            }
        }


        public void DeleteByUid(Guid reservationUid)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("@ID", reservationUid));
                    command.CommandText = RESERVATIONS_DELETE_BY_GUID;

                    command.ExecuteNonQuery();
                }
            }
        }

        private Reservation ConvertToModel(SqlDataReader dataReader)
        {
            Reservation reservation = new Reservation();
            reservation.ID = dataReader.GetGuid(dataReader.GetOrdinal("ID"));
            reservation.DateCreation = dataReader.GetString(dataReader.GetOrdinal("DateCreation"));
            reservation.CheckIn = dataReader.GetString(dataReader.GetOrdinal("CheckIn"));
            reservation.CheckOut = dataReader.GetString(dataReader.GetOrdinal("CheckOut"));
            reservation.NumberOfAdults = dataReader.GetString(dataReader.GetOrdinal("NumberOfAdults"));
            reservation.NumberOfChildren = dataReader.GetString(dataReader.GetOrdinal("NumberOfChildren"));
            reservation.Meal = dataReader.GetString(dataReader.GetOrdinal("Meal"));
            reservation.ReservationTypeID = dataReader.GetString(dataReader.GetOrdinal("ReservationTypeID"));
            reservation.GuestID = dataReader.GetString(dataReader.GetOrdinal("GuestID"));
            reservation.RoomID = dataReader.GetString(dataReader.GetOrdinal("RoomID"));

            return reservation;
        }
    }
}