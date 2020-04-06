using System;

namespace BusinessLayer
{
    public class RoomTypeBL
    {
        private RoomTypeDAL _roomTypeDAL;

        public RoomTypeBL(RoomTypeDAL roomTypeDAL)
        {
            _roomTypeDAL = roomTypeDAL;
        }

        public RoomType ReadByUid(Guid uid)
        {
            return _roomTypeDAL.ReadByUid(uid);
        }
    }
}
