using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Models
{
    public interface IReservation
    {
        IEnumerable<Reservation> AllReservations { get; }
    }
}
