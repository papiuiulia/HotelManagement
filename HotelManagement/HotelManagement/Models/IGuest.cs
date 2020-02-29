using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Models
{
    public interface IGuest
    {
        IEnumerable<Guest> AllGuests { get;  }
    }
}
