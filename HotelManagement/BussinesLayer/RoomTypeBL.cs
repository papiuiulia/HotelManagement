using DataAccessLayer;
using HotelManagement.Models;
using System;
using System.Collections.Generic;

namespace BussinesLayer
{
    public class RoomTypeBL
    {
        private RoomTypeDAL _roomTypeDAL;

        public RoomTypeBL(RoomTypeDAL roomTypeDAL)
        {
            _roomTypeDAL = roomTypeDAL;
        }

        public RoomType ReadById(Guid id)
        {
            return _roomTypeDAL.ReadById(id);
        }

        public List<RoomType> ReadAll()
        {
            return _roomTypeDAL.ReadAll();
        }

        public void DeleteById(Guid id)
        {
            _roomTypeDAL.DeleteById(id);
        }

        public void Insert(RoomType roomType)
        {
            _roomTypeDAL.InsertById(roomType);
        }

    }
}
