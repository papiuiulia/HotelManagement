using System;

namespace BusinessLayer
{
    public class AccommodationTypeBL
    {
        private AccommodationTypeDAL _accommodationTypeDAL;

        public AccommodationTypeBL(AccommodationTypeDAL accommodationTypeDAL)
        {
            _accommodationTypeDAL = accommodationTypeDAL;
        }

        public AccommodationType ReadByUid(Guid uid)
        {
            return _accommodationTypeDAL.ReadByUid(uid);
        }
    }
}