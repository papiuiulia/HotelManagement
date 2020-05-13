using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class AccommodationTypeDAL
    {
        private string _connectionString;
        private const string ACCOMMODATION_TYPE_READ_ALL = "dbo.AccommodationType_ReadAll";
        private const string ACCOMMODATION_TYPE_READ_BY_ID = "dbo.AccommodationType_ReadByGUID";
        private const string ACCOMMODATION_TYPE_UPDATE = "dbo.AccommodationType_UpdateByID";
        private const string ACCOMMODATION_TYPE_INSERT = "dbo.AccommodationType_InsertByID";
        private const string ACCOMMODATION_TYPE_DELETE_BY_ID = "dbo.AccommodationType_DeleteByID";

        public AccommodationTypeDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<AccommodationType> ReadAll()
        {
            List<AccommodationType> accomodationTypes = new List<AccommodationType>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = ACCOMMODATION_TYPE_READ_ALL;
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            AccommodationType accommodationType = new AccommodationType();
                            accommodationType = ConvertToModel(dataReader);
                            accomodationTypes.Add(accommodationType);
                        }
                    }
                }
            }

            return accomodationTypes;
        }

        public AccommodationType ReadById(Guid accommodationTypeId)
        {
            AccommodationType accommodationType = new AccommodationType();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText =   ACCOMMODATION_TYPE_READ_BY_ID;
                    command.Parameters.Add(new SqlParameter("@ID", accommodationTypeId));
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            accommodationType = ConvertToModel(dataReader);
                        }
                    }
                }
            }

            return accommodationType;
        }

        public void UpdateById(AccommodationType accommodationType)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "ACCOMMODATION_TYPE_UPDATE_BY_GUID";
                    command.Parameters.Add(new SqlParameter("@ID", accommodationType.ID));
                    command.Parameters.Add(new SqlParameter("@Type", accommodationType.Type));
                    command.ExecuteReader();
                }
            }
        }

        public void InsertById(AccommodationType accommodationType)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "ACCOMMODATION_TYPE_INSERT_BY_GUID";
                    command.Parameters.Add(new SqlParameter("@ID", accommodationType.ID));
                    command.Parameters.Add(new SqlParameter("@Type", accommodationType.Type));
                    command.ExecuteReader();
                }

            }
        }

        public void DeleteById(Guid accommodationTypeId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("@ID", accommodationTypeId));
                    command.CommandText = ACCOMMODATION_TYPE_DELETE_BY_ID;

                    command.ExecuteNonQuery();
                }
            }
        }

        private AccommodationType ConvertToModel(SqlDataReader dataReader)
        {
            AccommodationType accommodationType = new AccommodationType();
            accommodationType.ID = dataReader.GetGuid(dataReader.GetOrdinal("ID"));
            accommodationType.Type = dataReader.GetString(dataReader.GetOrdinal("Type"));

            return accommodationType;
        }
    }
}

