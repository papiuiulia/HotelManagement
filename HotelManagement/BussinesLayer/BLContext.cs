using System;
using DataAccessLayer;

namespace BussinesLayer
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

        public GuestTypeBL GuestTypeBL
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

        public GuestBL GuestBL
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

        public RoomTypeBL RoomTypeBL
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

        public AccommodationTypeBL AccommodationTypeBL
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

        public RoomBL RoomBL
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

        public ReservationTypeBL ReservationTypeBL
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

        public ReservationBL ReservationBL
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
