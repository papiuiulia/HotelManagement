using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Models
{
    public interface IGuestType
    {
        IEnumerable<GuestType> AllGuestTypes { get; }
    }
}
