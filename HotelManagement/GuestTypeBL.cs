using System;

namespace BusinessLayer
{
    public class GuestTypeBL
    {
        private GuestTypeDAL _guestTypeDAL;

        public GuestTypeBL(AccommodationTypeDAL guestTypeDAL)
        {
            _guestTypeDAL = guestTypeDAL;
        }

        public GuestType ReadByUid(Guid uid)
        {
            return _guestTypeDAL.ReadByUid(uid);
        }
    }
}