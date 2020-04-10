using BussinesLayer;
using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ServicesLayer.Controllers
{
    public class GuestTypeController : ApiController
    {

        private BLContext _blContext;

        public GuestTypeController(BLContext blContext)
        {
            _blContext = blContext;
        }

        public List<GuestType> GetAll()
        {
            return _blContext.GuestTypeBL.ReadAll();
        }

        [HttpGet]
        public GuestType ReadById(Guid id)
        {
            return _blContext.GuestTypeBL.ReadById(id);
        }

        [HttpDelete]
        public void DeleteById(Guid id)
        {
            _blContext.GuestTypeBL.DeleteById(id);
        }

        public void Insert(GuestType guestType)
        {
            _blContext.GuestTypeBL.Insert(guestType);
        }
    }
}