using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Models
{
    public interface IRoomType
    {
        IEnumerable<RoomType> AllRoomTypes { get; }
    }
}
