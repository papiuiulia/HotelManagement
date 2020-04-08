using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class ReservationTypeDAL
    {
        private const string _connectionString = "Server=IULIA-NOTEBOOK\\MSSQLSERVER2017;Database=master;Trusted_Connection=True;";
        private const string RESERVATION_TYPE_READ_ALL = "dbo.ReservationType_ReadAll";
        private const string RESERVATION_TYPE_READ_BY_ID = "dbo.ReservationType_ReadByGUID";
        private const string RESERVATION_TYPE_UPDATE = "dbo.ReservationType_UpdateByID";
        private const string RESERVATION_TYPE_INSERT = "dbo.ReservationType_InsertByID";
        private const string RESERVATION_TYPE_DELETE_BY_ID = "dbo.ReservationType_DeleteByID";

        public List<ReservationType> ReadAll()
        {
            List<ReservationType> reservationTypes = new List<ReservationType>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = RESERVATION_TYPE_READ_ALL;
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            ReservationType reservationType = ConvertToModel(dataReader);
                            reservationTypes.Add(reservationType);
                        }
                    }
                }
            }

            return reservationTypes;
        }

        public ReservationType ReadById(Guid reservationTypeId)
        {
            ReservationType reservationType = new ReservationType();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = RESERVATION_TYPE_READ_BY_ID;
                    command.Parameters.Add(new SqlParameter("@ID", reservationTypeId));
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            reservationType = ConvertToModel(dataReader);
                        }
                    }
                }
            }

            return reservationType;
        }

        public void UpdateById(ReservationType reservationType)
        {
            using (SqlConnnection connection = new SqlConnnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.ComandType.StoredProcedure;
                    command.CommandText = RESERVATION_TYPE_UPDATE_BY_ID;
                    command.Parameters.Add(new SqlParameter("@ID", reservationType.ID));
                    command.Parameters.Add(new SqlParameter("@Type", reservationType.Type));
                    command.ExecuteReader();
                }
            }
        }


        public void InsertById(ReservationType reservationType)
        {
            using (SqlConnnection connection = new SqlConnnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.ComandType.StoredProcedure;
                    command.CommandText = RESERVATION_TYPE_INSERT_BY_ID;
                    command.Parameters.Add(new SqlParameter("@ID", reservationType.ID));
                    command.Parameters.Add(new SqlParameter("@Type", reservationType.Type));
                    command.ExecuteReader();
                }

            }
        }


        public void DeleteById(Guid reservationTypeId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("@ID", reservationTypeId));
                    command.CommandText = RESERVATION_TYPE_DELETE_BY_ID;

                    command.ExecuteNonQuery();
                }
            }
        }

        private ReservationType ConvertToModel(SqlDataReader dataReader)
        {
            ReservationType reservationType = new ReservationType();
            reservationType.ID = dataReader.GetGuid(dataReader.GetOrdinal("ID"));
            reservationType.FirstName = dataReader.GetString(dataReader.GetOrdinal("Type"));
            
            return reservationType;
        }
    }
}
