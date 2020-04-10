using System;
using System.Collections.Generic;
using DataAccessLayer;
using HotelManagement.Models;

namespace BussinesLayer
{
    public class AccommodationTypeBL
    {
        private AccommodationTypeDAL _accommodationTypeDAL;

        public AccommodationTypeBL(AccommodationTypeDAL accommodationTypeDAL)
        {
            _accommodationTypeDAL = accommodationTypeDAL;
        }

        public AccommodationType ReadById(Guid id)
        {
            return _accommodationTypeDAL.ReadById(id);
        }

        public List<AccommodationType> GetAll()
        {
            return _accommodationTypeDAL.ReadAll();
        }

        public void DeleteById(Guid id)
        {
            _accommodationTypeDAL.DeleteById(id);
        }

        public void Insert(AccommodationType accommodationType)
        {
            _accommodationTypeDAL.InsertById(accommodationType);
        }
    }
}