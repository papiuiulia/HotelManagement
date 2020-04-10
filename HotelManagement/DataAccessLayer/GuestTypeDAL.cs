using HotelManagement.Models;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class GuestTypeDAL
    {
        private string _connectionString;
        private const string GUEST_TYPE_READ_ALL = "dbo.GuestType_ReadAll";
        private const string GUEST_TYPE_READ_BY_ID = "dbo.GuestType_ReadByGUID";
        private const string GUEST_TYPE_UPDATE = "dbo.GuestType_UpdateByID";
        private const string GUEST_TYPE_INSERT = "dbo.GuestType_InsertByID";
        private const string GUEST_TYPE_DELETE_BY_ID = "dbo.GuestType_DeleteByID";

        public GuestTypeDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<GuestType> ReadAll()
        {
            List<GuestType> guestTypes = new List<GuestType>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = GUEST_TYPE_READ_ALL;
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            GuestType guestType = ConvertToModel(dataReader);
                            guestTypes.Add(guestType);
                        }
                    }
                }
            }

            return guestTypes;
        }

        public GuestType ReadById(Guid guestTypeId)
        {
            GuestType guestType = new GuestType();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "GUESTS_READ_BY_ID";
                    command.Parameters.Add(new SqlParameter("@ID", guestTypeId));
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            guestType = ConvertToModel(dataReader);
                        }
                    }
                }
            }

            return guestType;
        }

        public void UpdateById(GuestType guestType)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType =CommandType.StoredProcedure;
                    command.CommandText = "GUEST_TYPE_UPDATE_BY_ID";
                    command.Parameters.Add(new SqlParameter("@ID", guestType.ID));
                    command.Parameters.Add(new SqlParameter("@Type", guestType.Type));
                    command.ExecuteReader();
                }
            }
        }


        public void InsertById(GuestType guestType)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GUEST_TYPE_INSERT_BY_ID";
                    command.Parameters.Add(new SqlParameter("@ID", guestType.ID));
                    command.Parameters.Add(new SqlParameter("@Type", guestType.Type));
                    command.ExecuteReader();
                }

            }
        }

        public void DeleteById(Guid guestTypeId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("@ID", guestTypeId));
                    command.CommandText = GUEST_TYPE_DELETE_BY_ID;

                    command.ExecuteNonQuery();
                }
            }
        }

        private GuestType ConvertToModel(SqlDataReader dataReader)
        {
            GuestType guestType = new GuestType();
            guestType.ID = dataReader.GetGuid(dataReader.GetOrdinal("ID"));
            guestType.Type = dataReader.GetString(dataReader.GetOrdinal("Type"));

            return guestType;
        }
    }
}