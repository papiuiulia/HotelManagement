using DataAccessLayer;
using Model;
using System;
using System.Collections.Generic;

namespace BussinesLayer
{
    public class RoomBL
    {
        private RoomDAL _roomDAL;

        public RoomBL(RoomDAL roomDAL)
        {
            _roomDAL = roomDAL;
        }

        public Room ReadById(Guid id)
        {
            return _roomDAL.ReadById(id);
        }

        public List<Room> ReadAll()
        {
            return _roomDAL.ReadAll();
        }

        public List<Room> GetAllAvailable()
        {
            return _roomDAL.GetAllAvailable();
        }

        public void DeleteById(Guid id) 
        {
            _roomDAL.DeleteById(id);
        }

        public void Insert(Room room)
        {
            _roomDAL.InsertById(room);
        }
    }
}
