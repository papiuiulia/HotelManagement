using System;

namespace BusinessLayer
{
    public class ReservationBL
    {
        private ReservationDAL _reservationDAL;

        public ReservationBL(ReservationDAL reservationDAL)
        {
            _reservationDAL = reservationDAL;
        }

        public Reservation ReadByUid(Guid uid)
        {
            return _reservationDAL.ReadByUid(uid);
        }
    }
}
