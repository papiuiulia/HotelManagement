using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Models
{
    public interface IReservationType
    {
        Guid ID { get; set; }
        string Type { get; set; }
    }
}
