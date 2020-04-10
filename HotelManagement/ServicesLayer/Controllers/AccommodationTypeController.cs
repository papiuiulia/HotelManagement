using System;
using System.Collections.Generic;
using System.Web.Http;
using HotelManagement.Models;
using BussinesLayer;

namespace ServicesLayer.Controllers
{
 
    public class AccommodationTypeController : ApiController
    {
        private BLContext _blContext;

        public AccommodationTypeController(BLContext blContext)
        {
            _blContext = blContext;
        }

        public List<AccommodationType> GetAll()
        {
            return _blContext.AccommodationTypeBL.GetAll();
        }

        [HttpGet]
        public AccommodationType ReadById(Guid id)
        {
            return _blContext.AccommodationTypeBL.ReadById(id);
        }

        [HttpDelete]
        public void DeleteById(Guid id)
        {
            _blContext.AccommodationTypeBL.DeleteById(id);
        }

        public void Insert(AccommodationType accommodationType)
        {
            _blContext.AccommodationTypeBL.Insert(accommodationType);
        }
    }
}
