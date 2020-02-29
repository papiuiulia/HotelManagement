using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Models
{
    public interface IRoom
    {
        IEnumerable<Room> AllRooms { get; }
    }
}
