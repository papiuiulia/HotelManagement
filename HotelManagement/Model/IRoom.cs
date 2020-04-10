using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Models
{
    public interface IRoom
    {
        Guid ID { get; set; }
        int RoomNr { get; set; }
        Guid RoomTypeID { get; set; }
        string AditionalInfo { get; set; }
        Guid TypeofAccommodationID { get; set; }
    }
}
