using System;
using System.Collections.Generic;
using System.Web.Http;
using BussinesLayer;
using HotelManagement.Models;

namespace ServicesLayer.Controllers
{
    public class GuestController : ApiController
    {
        private BLContext _blContext;

        public GuestController(BLContext blContext)
        {
            _blContext = blContext;
        }

        public List<Guest> GetAll()
        {
            return _blContext.GuestBL.ReadAll();
        }

        [HttpGet]
        public Guest ReadById(Guid id)
        {
            return _blContext.GuestBL.ReadById(id);
        }

        [HttpDelete]
        public void DeleteById(Guid id)
        {
            _blContext.GuestBL.DeleteById(id);
        }

        public void Insert(Guest guest)
        {
            _blContext.GuestBL.Insert(guest);
        }
    }
}
