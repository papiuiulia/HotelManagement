using BussinesLayer;
using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicesLayer.Controllers
{
    public class RoomTypeController : ApiController
    {
        private BLContext _blContext = new BLContext();

        [HttpGet]
        public List<RoomType> GetAll()
        {
            return _blContext.RoomTypeBL.ReadAll();
        }

        [HttpGet]
        public RoomType ReadById(Guid id)
        {
            return _blContext.RoomTypeBL.ReadById(id);
        }

        [HttpDelete]
        public void DeleteById(Guid id)
        {
            _blContext.RoomTypeBL.DeleteById(id);
        }

        public void Insert(RoomType roomType)
        {
            _blContext.RoomTypeBL.Insert(roomType);
        }
    }
}
