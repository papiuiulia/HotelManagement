using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class GuestsDAL
    {
        private const string _connectionString = "Server=IULIA-NOTEBOOK\\MSSQLSERVER2017;Database=master;Trusted_Connection=True;";
        private const string GUESTS_READ_ALL = "dbo.Guests_ReadAll";
        private const string GUESTS_READ_BY_GUID = "dbo.Guests_ReadByGUID";
        private const string GUESTS_UPDATE = "dbo.Guests_UpdateByID";
        private const string GUESTS_TYPE_INSERT = "dbo.Guests_InsertByID";
        private const string GUESTS_DELETE_BY_GUID = "dbo.Guests_DeleteByID";

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
                    command.CommandText = GUESTS_READ_ALL;
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

        public Guest ReadByUid(Guid guestUid)
        {
            Guest guest = new Guest();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = GUESTS_READ_BY_GUID;
                    command.Parameters.Add(new SqlParameter("@ID", guestUid));
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

        public void UpdateById(Guests guests)
        {
            using (SqlConnnection connection = new SqlConnnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.ComandType.StoredProcedure;
                    command.CommandText = GUESTS_UPDATE_BY_GUID;
                    command.Parameters.Add(new SqlParameter("@ID", guests.ID));
                    command.Parameters.Add(new SqlParameter("@FirstName", guests.FirstName));
                    command.Parameters.Add(new SqlParameter("@LastName", guests.LastName));
                    command.Parameters.Add(new SqlParameter("@Email", guests.Email));
                    command.Parameters.Add(new SqlParameter("@Phone", guests.Phone));
                    command.Parameters.Add(new SqlParameter("@Address", guests.Address));
                    command.Parameters.Add(new SqlParameter("@City", guests.City));
                    command.Parameters.Add(new SqlParameter("@Country", guests.Country));
                    command.Parameters.Add(new SqlParameter("@GuestTypeID", guests.GuestTypeID));
                    command.Parameters.Add(new SqlParameter("@AditionalInfo", guests.AditionalInfo));
                    command.ExecuteReader();
                }
            }
        }


        public void InsertById(Guests guests)
        {
            using (SqlConnnection connection = new SqlConnnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.ComandType.StoredProcedure;
                    command.CommandText = GUESTS_INSERT_BY_GUID;
                    command.Parameters.Add(new SqlParameter("@ID", guests.ID));
                    command.Parameters.Add(new SqlParameter("@FirstName", guests.FirstName));
                    command.Parameters.Add(new SqlParameter("@LastName", guests.LastName));
                    command.Parameters.Add(new SqlParameter("@Email", guests.Email));
                    command.Parameters.Add(new SqlParameter("@Phone", guests.Phone));
                    command.Parameters.Add(new SqlParameter("@Address", guests.Address));
                    command.Parameters.Add(new SqlParameter("@City", guests.City));
                    command.Parameters.Add(new SqlParameter("@Country", guests.Country));
                    command.Parameters.Add(new SqlParameter("@GuestTypeID", guests.GuestTypeID));
                    command.Parameters.Add(new SqlParameter("@AditionalInfo", guests.AditionalInfo));
                    command.ExecuteReader();
                }

            }
        }

        public void DeleteByUid(Guid guestUid)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("@ID", guestUid));
                    command.CommandText = GUESTS_DELETE_BY_GUID;
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
            guest.GuestTypeID = dataReader.GetString(dataReader.GetOrdinal("GuestTypeID"));
            guest.AditionalInfo = dataReader.GetDateTime(dataReader.GetOrdinal("AditionalInfo"));
            return guest;
        }
    }
}