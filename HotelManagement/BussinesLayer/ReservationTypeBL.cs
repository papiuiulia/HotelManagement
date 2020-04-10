using DataAccessLayer;
using HotelManagement.Models;
using System;
using System.Collections.Generic;

namespace BussinesLayer
{
    public class ReservationTypeBL
    {
        private ReservationTypeDAL _reservationTypeDAL;

        public ReservationTypeBL(ReservationTypeDAL reservationTypeDAL)
        {
            _reservationTypeDAL = reservationTypeDAL;
        }

        public ReservationType ReadById(Guid id)
        {
            return _reservationTypeDAL.ReadById(id);
        }

        public List<ReservationType> ReadAll()
        {
            return _reservationTypeDAL.ReadAll();
        }

        public void DeleteById(Guid id)
        {
            _reservationTypeDAL.DeleteById(id);
        }

        public void Insert(ReservationType reservationType) 
        {
            _reservationTypeDAL.InsertById(reservationType);
        }
    }
}
