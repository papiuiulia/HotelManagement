using System;
using System.Collections.Generic;
using System.Web.Http;
using BussinesLayer;
using HotelManagement.Models;

namespace ServicesLayer.Controllers
{
    public class ReservationController : ApiController
    {
        private BLContext _blContext = new BLContext();

        [HttpGet]
        public List<Reservation> GetAll()
        {
            return _blContext.ReservationBL.ReadAll();
        }

        [HttpGet]
        public Reservation ReadById(Guid id)
        {
            return _blContext.ReservationBL.ReadById(id);
        }

        [HttpDelete]
        public void DeleteById(Guid id)
        {
            _blContext.ReservationBL.DeleteById(id);
        }

        [HttpPost]
        public void Insert([FromBody] Reservation reservation)
        {
            _blContext.ReservationBL.Insert(reservation);
        }
    }
}