using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALContext
    {
        private const string _connectionString = "Server=IULIA-NOTEBOOK\\MSSQLSERVER2017;Database=master;Trusted_Connection=True;";
        private AccommodationTypeDAL _accommodationTypeDAL;
        private GuestDAL _guestDAL;
        private GuestTypeDAL _guestTypeDAL;
        private ReservationDAL _reservationDAL;
        private ReservationTypeDAL _reservationTypeDAL;
        private RoomDAL _roomDAL;
        private RoomTypeDAL _roomTypeDAL;

        public AccommodationTypeDAL AccommodationTypeDAL
        {
            get
            {
                if (_accommodationTypeDAL == null)
                {
                    _accommodationTypeDAL = new AccommodationTypeDAL(_connectionString);
                }
                return _accommodationTypeDAL;
            }
        }

        public GuestDAL GuestDAL
        {
            get
            {
                if (_guestDAL == null)
                {
                    _guestDAL = new GuestDAL(_connectionString);
                }
                return _guestDAL;
            }
        }

        public GuestTypeDAL GuestTypeDAL
        {
            get
            {
                if (_guestTypeDAL == null)
                {
                    _guestTypeDAL = new GuestTypeDAL(_connectionString);
                }
                return _guestTypeDAL;
            }
        }

        public ReservationDAL ReservationDAL
        {
            get
            {
                if (_reservationDAL == null)
                {
                    _reservationDAL = new ReservationDAL(_connectionString);
                }
                return _reservationDAL;
            }
        }

        public ReservationTypeDAL ReservationTypeDAL
        {
            get
            {
                if (_reservationTypeDAL == null)
                {
                    _reservationTypeDAL = new ReservationTypeDAL(_connectionString);
                }
                return _reservationTypeDAL;
            }
        }

        public RoomDAL RoomDAL
        {
            get
            {
                if (_roomDAL == null)
                {
                    _roomDAL = new RoomDAL(_connectionString);
                }
                return _roomDAL;
            }
        }

        public RoomTypeDAL RoomTypeDAL
        {
            get
            {
                if (_roomTypeDAL == null)
                {
                    _roomTypeDAL = new RoomTypeDAL(_connectionString);
                }
                return _roomTypeDAL;
            }
        }
    }
}
