using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class GuestDAL
    {
        private string _connectionString;
        private const string GUEST_READ_ALL = "dbo.Guests_ReadAll";
        private const string GUEST_READ_BY_ID = "dbo.Guests_ReadByGUID";
        private const string GUEST_UPDATE = "dbo.Guests_UpdateByID";
        private const string GUEST_TYPE_INSERT = "dbo.Guests_InsertByID";
        private const string GUEST_DELETE_BY_ID = "dbo.Guests_DeleteByID";

        public GuestDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Guest> ReadAll()
        {
            List<Guest> guests = new List<Guest>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = GUEST_READ_ALL;
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Guest guest = ConvertToModel(dataReader);
                            guests.Add(guest);
                        }
                    }
                }
            }

            return guests;
        }

        public Guest ReadById(Guid guestId)
        {
            Guest guest = new Guest();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = GUEST_READ_BY_ID;
                    command.Parameters.Add(new SqlParameter("@ID", guestId));
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            guest = ConvertToModel(dataReader);
                        }
                    }
                }
            }

            return guest;
        }

        public void UpdateById(Guest guest)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "GUESTS_UPDATE_BY_GUID";
                    command.Parameters.Add(new SqlParameter("@ID", guest.ID));
                    command.Parameters.Add(new SqlParameter("@FirstName", guest.FirstName));
                    command.Parameters.Add(new SqlParameter("@LastName", guest.LastName));
                    command.Parameters.Add(new SqlParameter("@Email", guest.Email));
                    command.Parameters.Add(new SqlParameter("@Phone", guest.Phone));
                    command.Parameters.Add(new SqlParameter("@Address", guest.Address));
                    command.Parameters.Add(new SqlParameter("@City", guest.City));
                    command.Parameters.Add(new SqlParameter("@Country", guest.Country));
                    command.Parameters.Add(new SqlParameter("@GuestTypeID", guest.GuestTypeID));
                    command.Parameters.Add(new SqlParameter("@AditionalInfo", guest.AditionalInfo));
                    command.ExecuteReader();
                }
            }
        }


        public void InsertById(Guest guest)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GUESTS_INSERT_BY_GUID";
                    command.Parameters.Add(new SqlParameter("@ID", guest.ID));
                    command.Parameters.Add(new SqlParameter("@FirstName", guest.FirstName));
                    command.Parameters.Add(new SqlParameter("@LastName", guest.LastName));
                    command.Parameters.Add(new SqlParameter("@Email", guest.Email));
                    command.Parameters.Add(new SqlParameter("@Phone", guest.Phone));
                    command.Parameters.Add(new SqlParameter("@Address", guest.Address));
                    command.Parameters.Add(new SqlParameter("@City", guest.City));
                    command.Parameters.Add(new SqlParameter("@Country", guest.Country));
                    command.Parameters.Add(new SqlParameter("@GuestTypeID", guest.GuestTypeID));
                    command.Parameters.Add(new SqlParameter("@AditionalInfo", guest.AditionalInfo));
                    command.ExecuteReader();
                }

            }
        }

        public void DeleteById(Guid guestId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("@ID", guestId));
                    command.CommandText = GUEST_DELETE_BY_ID;
                    command.ExecuteNonQuery();
                }
            }
        }

        private Guest ConvertToModel(SqlDataReader dataReader)
        {
            Guest guest = new Guest();
            guest.ID = dataReader.GetGuid(dataReader.GetOrdinal("ID"));
            guest.FirstName = dataReader.GetString(dataReader.GetOrdinal("FirstName"));
            guest.LastName = dataReader.GetString(dataReader.GetOrdinal("LastName"));
            guest.Email = dataReader.GetString(dataReader.GetOrdinal("Email"));
            guest.Phone = dataReader.GetString(dataReader.GetOrdinal("Phone"));
            guest.Address = dataReader.GetString(dataReader.GetOrdinal("Address"));
            guest.City = dataReader.GetString(dataReader.GetOrdinal("City"));
            guest.Country = dataReader.GetString(dataReader.GetOrdinal("Country"));
            guest.GuestTypeID = new Guid(dataReader.GetString(dataReader.GetOrdinal("GuestTypeID")));
            guest.AditionalInfo = dataReader.GetDateTime(dataReader.GetOrdinal("AditionalInfo")).ToString();
            return guest;
        }
    }
}