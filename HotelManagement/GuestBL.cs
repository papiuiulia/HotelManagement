using System;

namespace BusinessLayer
{
    public class GuestBL
    {
        private GuestDAL _GuestDAL;

        public GuestBL(GuestDAL guestDAL)
        {
            _guestDAL = guestDAL;
        }

        public Guest ReadByUid(Guid uid)
        {
            return _guestDAL.ReadByUid(uid);
        }
    }
}
