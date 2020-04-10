using DataAccessLayer;
using HotelManagement.Models;
using System;
using System.Collections.Generic;

namespace BussinesLayer
{
    public class GuestTypeBL
    {
        private GuestTypeDAL _guestTypeDAL;

        public GuestTypeBL(GuestTypeDAL guestTypeDAL)
        {
            _guestTypeDAL = guestTypeDAL;
        }

        public GuestType ReadById(Guid id)
        {
            return _guestTypeDAL.ReadById(id);
        }

        public List<GuestType> ReadAll()
        {
            return _guestTypeDAL.ReadAll();
        }

        public void DeleteById(Guid id)
        {
            _guestTypeDAL.DeleteById(id);
        }

        public void Insert(GuestType guestType)
        {
            _guestTypeDAL.InsertById(guestType);
        }
    }
}