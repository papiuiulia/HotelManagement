using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class GuestTypesDAL
    {
        private const string _connectionString = "Server=IULIA-NOTEBOOK\\MSSQLSERVER2017;Database=master;Trusted_Connection=True;";
        private const string GUEST_TYPE_READ_ALL = "dbo.GuestType_ReadAll";
        private const string GUEST_TYPE_READ_BY_GUID = "dbo.GuestType_ReadByGUID";
        private const string GUEST_TYPE_UPDATE = "dbo.GuestType_UpdateByID";
        private const string GUEST_TYPE_INSERT = "dbo.GuestType_InsertByID";
        private const string GUEST_TYPE_DELETE_BY_GUID = "dbo.GuestType_DeleteByID";

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
                            guestType.Add(guesttype);
                        }
                    }
                }
            }

            return guestTypes;
        }

        public GuestType ReadByUid(Guid guestTypeUid)
        {
            GuestType guestType = new GuestType();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = GUESTS_READ_BY_GUID;
                    command.Parameters.Add(new SqlParameter("@ID", guestTypeUid));
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
            using (SqlConnnection connection = new SqlConnnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.ComandType.StoredProcedure;
                    command.CommandText = GUEST_TYPE_UPDATE_BY_GUID;
                    command.Parameters.Add(new SqlParameter("@ID", guestType.ID));
                    command.Parameters.Add(new SqlParameter("@Type", guestType.Type));
                    command.ExecuteReader();
                }
            }
        }


        public void InsertById(GuestType guestType)
        {
            using (SqlConnnection connection = new SqlConnnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.ComandType.StoredProcedure;
                    command.CommandText = GUEST_TYPE_INSERT_BY_GUID;
                    command.Parameters.Add(new SqlParameter("@ID", guestType.ID));
                    command.Parameters.Add(new SqlParameter("@Type", guestType.Type));
                    command.ExecuteReader();
                }

            }
        }


        public void DeleteByUid(Guid guestTypeUid)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("@ID", guestTypeUid));
                    command.CommandText = GUEST_TYPE_DELETE_BY_GUID;

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