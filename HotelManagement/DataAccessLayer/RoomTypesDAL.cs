using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class RoomTypesDAL
    {
        private const string _connectionString = "Server=IULIA-NOTEBOOK\\MSSQLSERVER2017;Database=master;Trusted_Connection=True;";
        private const string ROOM_TYPE_READ_ALL = "dbo.RoomType_ReadAll";
        private const string ROOM_TYPE_READ_BY_GUID = "dbo.RoomType_ReadByGUID";
        private const string ROOM_TYPE_UPDATE = "dbo.RoomType_UpdateByID";
        private const string ROOM_TYPE_INSERT = "dbo.RoomType_InsertByID";
        private const string ROOM_TYPE_DELETE_BY_GUID = "dbo.RoomType_DeleteByID";

        public List<RoomType> ReadAll()
        {
            List<RoomType> roomTypes = new List<RoomType>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = ROOM_TYPE_READ_ALL;
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            RoomType roomType = ConvertToModel(dataReader);
                            roomType.Add(roomtype);
                        }
                    }
                }
            }

            return roomTypes;
        }

        public RoomType ReadByUid(Guid roomTypeUid)
        {
            RoomType roomType = new RoomType();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = ROOM_TYPE_READ_BY_GUID;
                    command.Parameters.Add(new SqlParameter("@ID", roomTypeUid));
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            roomType = ConvertToModel(dataReader);
                        }
                    }
                }
            }

            return roomType;
        }

        public void UpdateById(RoomTypesDAL roomType) 
        {
            using (SqlConnnection connection = new SqlConnnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.ComandType.StoredProcedure;
                    command.CommandText = ROOM_TYPE_UPDATE_BY_GUID;
                    command.Parameters.Add(new SqlParameter("@ID", roomType.ID));
                    command.Parameters.Add(new SqlParameter("@Name", roomType.Name));
                    command.Parameters.Add(new SqlParameter("@Price", roomType.Price));
                    command.ExecuteReader();
                }
            }
        }

       
        public void InsertById(RoomType roomType) {
            using (SqlConnnection connection = new SqlConnnection(_connectionString))
            {
                connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = System.Data.ComandType.StoredProcedure;
                        command.CommandText = ROOM_TYPE_INSERT_BY_GUID;
                        command.Parameters.Add(new SqlParameter("@ID", roomType.ID));
                        command.Parameters.Add(new SqlParameter("@Name", roomType.Name));
                        command.Parameters.Add(new SqlParameter("@Price", roomType.Price));
                        command.ExecuteReader();
                    }

                }
        }

        public void DeleteByUid(Guid roomTypeUid)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("@ID", roomTypeUid));
                    command.CommandText = ROOM_TYPE_DELETE_BY_GUID;

                    command.ExecuteNonQuery();
                }
            }
        }

        private RoomType ConvertToModel(SqlDataReader dataReader)
        {
            RoomTypeD roomType = new RoomType();
            roomType.ID = dataReader.GetGuid(dataReader.GetOrdinal("ID"));
            roomType.Name = dataReader.GetString(dataReader.GetOrdinal("Name"));
            roomType.Price = dataReader.GetString(dataReader.GetOrdinal("Price"));

            return roomType;
        }
    }
}
