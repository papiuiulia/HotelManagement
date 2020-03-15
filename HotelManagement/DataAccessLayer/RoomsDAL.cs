using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class RoomsDAL
    {
        private const string _connectionString = "Server=IULIA-NOTEBOOK\\MSSQLSERVER2017;Database=master;Trusted_Connection=True;";
        private const string ROOMS_READ_ALL = "dbo.Rooms_ReadAll";
        private const string ROOMS_READ_BY_GUID = "dbo.Rooms_ReadByGUID";
        private const string ROOMS_UPDATE = "dbo.Rooms_UpdateByID";
        private const string ROOMS_INSERT = "dbo.Rooms_InsertByID";
        private const string ROOMS_DELETE_BY_GUID = "dbo.Rooms_DeleteByID";

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
                    command.CommandText = ROOMS_READ_ALL;
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

        public Room ReadByUid(Guid roomUid)
        {
            Room room = new Room();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = ROOMS_READ_BY_GUID;
                    command.Parameters.Add(new SqlParameter("@ID", roomUid));
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

        public void UpdateById(RoomsDAL rooms)
        {
            using (SqlConnnection connection = new SqlConnnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.ComandType.StoredProcedure;
                    command.CommandText = ROOMS_UPDATE_BY_GUID;
                    command.Parameters.Add(new SqlParameter("@ID", rooms.ID));
                    command.Parameters.Add(new SqlParameter("@RoomNr", rooms.RoomNr));
                    command.Parameters.Add(new SqlParameter("@RoomTypeID", rooms.RoomTypeID));
                    command.Parameters.Add(new SqlParameter("@AditionalInfo", rooms.AditionalInfo));
                    command.Parameters.Add(new SqlParameter("@TypeOfAccommodation", rooms.TypeOfAccommodationID));
                    command.ExecuteReader();
                }
            }
        }


        public void InsertById(Rooms rooms)
        {
            using (SqlConnnection connection = new SqlConnnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.ComandType.StoredProcedure;
                    command.CommandText = ROOMS_INSERT_BY_GUID;
                    command.Parameters.Add(new SqlParameter("@ID", rooms.ID));
                    command.Parameters.Add(new SqlParameter("@RoomNr", rooms.RoomNr));
                    command.Parameters.Add(new SqlParameter("@RoomTypeID", rooms.RoomTypeID));
                    command.Parameters.Add(new SqlParameter("@AditionalInfo", rooms.AditionalInfo));
                    command.Parameters.Add(new SqlParameter("@TypeOfAccommodation", rooms.TypeOfAccommodationID));
                    command.ExecuteReader();
                }

            }
        }

        public void DeleteByUid(Guid roomUid)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter("@ID", roomUid));
                    command.CommandText = ROOM_DELETE_BY_GUID;

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
