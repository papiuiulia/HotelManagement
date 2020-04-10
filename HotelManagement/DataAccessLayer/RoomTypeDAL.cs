using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class RoomTypeDAL
    {
        private string _connectionString;
        private const string ROOM_TYPE_READ_ALL = "dbo.RoomType_ReadAll";
        private const string ROOM_TYPE_READ_BY_ID = "dbo.RoomType_ReadByGUID";
        private const string ROOM_TYPE_UPDATE = "dbo.RoomType_UpdateByID";
        private const string ROOM_TYPE_INSERT = "dbo.RoomType_InsertByID";
        private const string ROOM_TYPE_DELETE_BY_ID = "dbo.RoomType_DeleteByID";

        public RoomTypeDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

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
                    command.CommandText = "ROOM_TYPE_READ_ALL";
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            RoomType roomType = ConvertToModel(dataReader);
                            roomTypes.Add(roomType);
                        }
                    }
                }
            }

            return roomTypes;
        }

        public RoomType ReadById(Guid roomTypeId)
        {
            RoomType roomType = new RoomType();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = ROOM_TYPE_READ_BY_ID;
                    command.Parameters.Add(new SqlParameter("@ID", roomTypeId));
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

        public void UpdateById(RoomType roomType) 
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "ROOM_TYPE_UPDATE_BY_ID";
                    command.Parameters.Add(new SqlParameter("@ID", roomType.ID));
                    command.Parameters.Add(new SqlParameter("@Name", roomType.Name));
                    command.Parameters.Add(new SqlParameter("@Price", roomType.Price));
                    command.ExecuteReader();
                }
            }
        }

       
        public void InsertById(RoomType roomType) {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "ROOM_TYPE_INSERT_BY_ID";
                        command.Parameters.Add(new SqlParameter("@ID", roomType.ID));
                        command.Parameters.Add(new SqlParameter("@Name", roomType.Name));
                        command.Parameters.Add(new SqlParameter("@Price", roomType.Price));
                        command.ExecuteReader();
                    }

                }
        }

        public void DeleteById(Guid roomTypeId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("@ID", roomTypeId));
                    command.CommandText = ROOM_TYPE_DELETE_BY_ID;

                    command.ExecuteNonQuery();
                }
            }
        }

        private RoomType ConvertToModel(SqlDataReader dataReader)
        {
            RoomType roomType = new RoomType();
            roomType.ID = dataReader.GetGuid(dataReader.GetOrdinal("ID"));
            roomType.Name = dataReader.GetString(dataReader.GetOrdinal("Name"));
            roomType.Price = dataReader.GetDecimal(dataReader.GetOrdinal("Price"));

            return roomType;
        }
    }
}
