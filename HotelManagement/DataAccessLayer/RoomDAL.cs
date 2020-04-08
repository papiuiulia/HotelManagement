using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class RoomsDAL
    {
        private const string _connectionString = "Server=IULIA-NOTEBOOK\\MSSQLSERVER2017;Database=master;Trusted_Connection=True;";
        private const string ROOM_READ_ALL = "dbo.Rooms_ReadAll";
        private const string ROOM_READ_BY_ID = "dbo.Rooms_ReadByGUID";
        private const string ROOM_UPDATE = "dbo.Rooms_UpdateByID";
        private const string ROOM_INSERT = "dbo.Rooms_InsertByID";
        private const string ROOM_DELETE_BY_ID = "dbo.Rooms_DeleteByID";

        public List<Room> ReadAll()
        {
            List<Room> rooms = new List<Room>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = ROOM_READ_ALL;
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            Room room = ConvertToModel(dataReader);
                            rooms.Add(room);
                        }
                    }
                }
            }

            return rooms;
        }

        public Room ReadById(Guid roomId)
        {
            Room room = new Room();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = ROOM_READ_BY_ID;
                    command.Parameters.Add(new SqlParameter("@ID", roomId));
                    using (SqlDataReader dataReader = command.ExecuteReader())
                    {
                        if (dataReader.Read())
                        {
                            room = ConvertToModel(dataReader);
                        }
                    }
                }
            }

            return room;
        }

        public void UpdateById(Room room)
        {
            using (SqlConnnection connection = new SqlConnnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.ComandType.StoredProcedure;
                    command.CommandText = ROOMS_UPDATE_BY_GUID;
                    command.Parameters.Add(new SqlParameter("@ID", room.ID));
                    command.Parameters.Add(new SqlParameter("@RoomNr", room.RoomNr));
                    command.Parameters.Add(new SqlParameter("@RoomTypeID", room.RoomTypeID));
                    command.Parameters.Add(new SqlParameter("@AditionalInfo", room.AditionalInfo));
                    command.Parameters.Add(new SqlParameter("@TypeOfAccommodation", room.TypeOfAccommodationID));
                    command.ExecuteReader();
                }
            }
        }

        public void InsertById(Room room)
        {
            using (SqlConnnection connection = new SqlConnnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.ComandType.StoredProcedure;
                    command.CommandText = ROOMS_INSERT_BY_GUID;
                    command.Parameters.Add(new SqlParameter("@ID", room.ID));
                    command.Parameters.Add(new SqlParameter("@RoomNr", room.RoomNr));
                    command.Parameters.Add(new SqlParameter("@RoomTypeID", room.RoomTypeID));
                    command.Parameters.Add(new SqlParameter("@AditionalInfo", room.AditionalInfo));
                    command.Parameters.Add(new SqlParameter("@TypeOfAccommodation", room.TypeOfAccommodationID));
                    command.ExecuteReader();
                }

            }
        }

        public void DeleteById(Guid roomId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("@ID", roomId));
                    command.CommandText = ROOM_DELETE_BY_ID;

                    command.ExecuteNonQuery();
                }
            }
        }

        private Room ConvertToModel(SqlDataReader dataReader)
        {
            Room room = new Room();
            room.ID = dataReader.GetGuid(dataReader.GetOrdinal("ID"));
            room.RoomNr = dataReader.GetString(dataReader.GetOrdinal("RoomNr"));
            room.RoomTypeID = dataReader.GetString(dataReader.GetOrdinal("RoomTypeID"));
            room.AditionalInfo = dataReader.GetString(dataReader.GetOrdinal("AditionalInfo"));
            room.TypeOfAccommodationID = dataReader.GetString(dataReader.GetOrdinal("TypeofAccommodationID"));

            return room;
        }
    }
}
