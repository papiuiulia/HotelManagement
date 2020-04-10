using System;
using System.Collections.Generic;
using DataAccessLayer;
using HotelManagement.Models;
using Model;

namespace BussinesLayer
{
    public class GuestBL
    {
        private GuestDAL _guestDAL;

        public GuestBL(GuestDAL guestDAL)
        {
            _guestDAL = guestDAL;
        }

        public Guest ReadById(Guid id)
        {
            return _guestDAL.ReadById(id);
        }

        public List<Guest> ReadAll()
        {
            return _guestDAL.ReadAll();
        }

        public void DeleteById(Guid id)
        {
            _guestDAL.DeleteById(id);
        }

        public void Insert(Guest guest)
        {
            _guestDAL.InsertById(guest);
        }
    }
}
