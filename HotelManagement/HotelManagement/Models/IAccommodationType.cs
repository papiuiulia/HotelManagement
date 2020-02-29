using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Models
{
    public interface IAccommodationType
    {
        IEnumerable<AccommodationType> AllAccommodationTypes { get;  }
    }
}
