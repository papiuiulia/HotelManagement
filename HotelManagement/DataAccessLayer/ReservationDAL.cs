﻿using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class ReservationDAL
    {
        private string _connectionString;
        private const string RESERVATION_READ_ALL = "dbo.Reservations_ReadAll";
        private const string RESERVATION_READ_BY_ID = "dbo.Reservations_ReadByGUID";
        private const string RESERVATION_UPDATE = "dbo.Reservations_UpdateByID";
        private const string RESERVATION_TYPE_INSERT = "dbo.Reservation_Insert";
        private const string RESERVATION_DELETE_BY_ID = "dbo.Reservations_DeleteByID";

        public ReservationDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

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
                    command.CommandText = RESERVATION_READ_ALL;
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

        public Reservation ReadById(Guid reservationId)
        {
            Reservation reservation = new Reservation();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = RESERVATION_READ_BY_ID;
                    command.Parameters.Add(new SqlParameter("@ID", reservationId));
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

        public void UpdateById(Reservation reservation)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "RESERVATIONS_UPDATE_BY_ID";
                    command.Parameters.Add(new SqlParameter("@ID", reservation.ID));
                    command.Parameters.Add(new SqlParameter("@DateCreation", reservation.DateCreation));
                    command.Parameters.Add(new SqlParameter("@CheckIn", reservation.CheckIn));
                    command.Parameters.Add(new SqlParameter("@CheckOut", reservation.CheckOut));
                    command.Parameters.Add(new SqlParameter("@NumberOfAdults", reservation.NumberOfAdults));
                    command.Parameters.Add(new SqlParameter("@NumberOfChildren", reservation.NumberOfChildren));
                    command.Parameters.Add(new SqlParameter("@Meal", reservation.Meal));
                    command.Parameters.Add(new SqlParameter("@ReservationTypeID", reservation.ReservationTypeID));
                    command.Parameters.Add(new SqlParameter("@GuestID", reservation.GuestID));
                    command.Parameters.Add(new SqlParameter("@RoomID", reservation.RoomID));
                    command.ExecuteReader();
                }
            }
        }

        public void InsertById(Reservation reservation)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = RESERVATION_TYPE_INSERT;
                    command.Parameters.Add(new SqlParameter("@ID", reservation.ID));
                    command.Parameters.Add(new SqlParameter("@DateCreation", reservation.DateCreation));
                    command.Parameters.Add(new SqlParameter("@CheckIn", reservation.CheckIn));
                    command.Parameters.Add(new SqlParameter("@CheckOut", reservation.CheckOut));
                    command.Parameters.Add(new SqlParameter("@NumberOfAdults", reservation.NumberOfAdults));
                    command.Parameters.Add(new SqlParameter("@NumberOfChildren", reservation.NumberOfChildren));
                    command.Parameters.Add(new SqlParameter("@Meal", reservation.Meal));
                    command.Parameters.Add(new SqlParameter("@ReservationTypeID", reservation.ReservationTypeID));
                    command.Parameters.Add(new SqlParameter("@GuestID", reservation.GuestID));
                    command.Parameters.Add(new SqlParameter("@RoomID", reservation.RoomID));
                    command.ExecuteReader();
                }

            }
        }

        public void DeleteById(Guid reservationId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("@ID", reservationId));
                    command.CommandText = RESERVATION_DELETE_BY_ID;

                    command.ExecuteNonQuery();
                }
            }
        }

        private Reservation ConvertToModel(SqlDataReader dataReader)
        {
            Reservation reservation = new Reservation();
            reservation.ID = dataReader.GetGuid(dataReader.GetOrdinal("ID"));
            reservation.DateCreation = dataReader.GetDateTime(dataReader.GetOrdinal("DateCreation"));
            reservation.CheckIn = dataReader.GetDateTime(dataReader.GetOrdinal("CheckIn"));
            reservation.CheckOut = dataReader.GetDateTime(dataReader.GetOrdinal("CheckOut"));
            reservation.NumberOfAdults = dataReader.GetInt32(dataReader.GetOrdinal("NumberOfAdults"));
            reservation.NumberOfChildren = dataReader.GetInt32(dataReader.GetOrdinal("NumberOfChildren"));
            reservation.Meal = dataReader.GetBoolean(dataReader.GetOrdinal("Meal"));
            reservation.ReservationTypeID = dataReader.GetGuid(dataReader.GetOrdinal("ReservationTypeID"));
            reservation.GuestID = dataReader.GetGuid(dataReader.GetOrdinal("GuestID"));
            reservation.RoomID = dataReader.GetGuid(dataReader.GetOrdinal("RoomID"));

            return reservation;
        }
    }
}