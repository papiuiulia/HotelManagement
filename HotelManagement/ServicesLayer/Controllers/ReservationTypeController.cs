using System;
using System.Collections.Generic;
using System.Web.Http;
using BussinesLayer;
using HotelManagement.Models;

namespace ServicesLayer.Controllers
{
    public class ReservationTypeController : ApiController
    {
        private BLContext _blContext;

        public ReservationTypeController(BLContext blContext)
        {
            _blContext = blContext;
        }

        public List<ReservationType> GetAll()
        {
            return _blContext.ReservationTypeBL.ReadAll();
        }

        [HttpGet]
        public ReservationType ReadById(Guid id)
        {
            return _blContext.ReservationTypeBL.ReadById(id);
        }

        [HttpDelete]
        public void DeleteById(Guid id)
        {
            _blContext.ReservationTypeBL.DeleteById(id);
        }

        public void Insert(ReservationType reservationType)
        {
            _blContext.ReservationTypeBL.Insert(reservationType);
        }
    }
}