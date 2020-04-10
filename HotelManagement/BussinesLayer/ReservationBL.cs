using DataAccessLayer;
using HotelManagement.Models;
using System;
using System.Collections.Generic;

namespace BussinesLayer
{
    public class ReservationBL
    {
        private ReservationDAL _reservationDAL;

        public ReservationBL(ReservationDAL reservationDAL)
        {
            _reservationDAL = reservationDAL;
        }

        public Reservation ReadById(Guid id)
        {
            return _reservationDAL.ReadById(id);
        }

        public List<Reservation> ReadAll()
        {
            return _reservationDAL.ReadAll();
        }

        public void DeleteById(Guid id)
        {
            _reservationDAL.DeleteById(id);
        }

        public void Insert(Reservation reservation)
        {
            _reservationDAL.InsertById(reservation);
        }

    }
}
