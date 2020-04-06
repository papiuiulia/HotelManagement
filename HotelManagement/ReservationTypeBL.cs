using System;

namespace BusinessLayer
{
    public class ReservationTypeBL
    {
        private reservationTypeDAL _reservationTypeDAL;

        public ReservationTypeBL(ReservationTypeDAL reservationTypeDAL)
        {
            _reservationTypeDAL = reservationTypeDAL;
        }

        public ReservationType ReadByUid(Guid uid)
        {
            return _reservationTypeDAL.ReadByUid(uid);
        }
    }
}
