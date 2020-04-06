using System;

namespace BusinessLayer
{
    public class RoomBL
    {
        private RoomDAL _roomDAL;

        public RoomBL(RoomDAL roomDAL)
        {
            _roomDAL = roomDAL;
        }

        public Room ReadByUid(Guid uid)
        {
            return _room.ReadByUid(uid);
        }
    }
}
