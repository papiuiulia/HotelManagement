using System;

namespace BusinessLayer
{
    public class BLContext
    {
        private DALContext _dalContext = new DALContext();
        private GuestTypeBL _guestTypeBL;
        private GuestBL _guestBL;
        private RoomTypeBL _roomTypeBL;
        private AccommodationTypeBL _accommodationTypeBL;
        private RoomBL _roomBL;
        private ReservationTypeBL _reservationTypeBL;
        private ReservationBL _reservationBL;

        public GuestTypeBL GuestTypeDAL
        {
            get
            {
                if (_guestTypeBL == null)
                {
                    _guestTypeBL = new GuestTypeBL(_dalContext.GuestTypeDAL);
                }
                return _guestTypeBL;
            }
        }

        public GuestBL GuestDAL
        {
            get
            {
                if (_guestBL == null)
                {
                    _guestBL = new GuestBL(_dalContext.GuestDAL);
                }
                return _guestBL;
            }
        }

        public RoomTypeBL RoomTypeDAL
        {
            get
            {
                if (_roomTypeBL == null)
                {
                    _roomTypeBL = new RoomTypeBL(_dalContext.RoomTypeDAL);
                }
                return _roomTypeBL;
            }
        }

        public AccommodationTypeBL AccommodationTypeDAL
        {
            get
            {
                if (_accommodationTypeBL == null)
                {
                    _accommodationTypeBL = new AccommodationTypeBL(_dalContext.AccommodationTypeDAL);
                }
                return _accommodationTypeBL;
            }
        }

        public RoomBL RoomDAL
        {
            get
            {
                if (_roomBL == null)
                {
                    _roomBL = new RoomBL(_dalContext.RoomDAL);
                }
                return _roomBL;
            }
        }

        public ReservationTypeBL ReservationTypeDAL
        {
            get
            {
                if (_reservationTypeBL == null)
                {
                    _reservationTypeBL = new ReservationTypeBL(_dalContext.ReservationTypeDAL);
                }
                return _reservationTypeBL;
            }
        }

        public ReservationBL ReservationDAL
        {
            get
            {
                if (_reservationBL == null)
                {
                    _reservationBL = new ReservationBL(_dalContext.ReservationDAL);
                }
                return _reservationBL;
            }
        }
    }
}
