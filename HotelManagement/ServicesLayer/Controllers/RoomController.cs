using BussinesLayer;
using Model;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace ServicesLayer.Controllers
{
    public class RoomController : ApiController
    {
        private BLContext _blContext = new BLContext();

        [HttpGet]
        public List<Room> GetAll()
        {
            return _blContext.RoomBL.ReadAll();
        }

        [HttpGet]
        public Room ReadById(Guid id)
        {
            return _blContext.RoomBL.ReadById(id);
        }

        [HttpDelete]
        public void DeleteById(Guid id)
        {
            _blContext.RoomBL.DeleteById(id);
        }

        public void Insert(Room room)
        {
            _blContext.RoomBL.Insert(room);
        }
    }
}
