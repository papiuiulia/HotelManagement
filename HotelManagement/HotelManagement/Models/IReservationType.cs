using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Models
{
    public interface IReservationType
    {
        IEnumerable<IReservationType> AllReservationTypes { get; }
    }
}
