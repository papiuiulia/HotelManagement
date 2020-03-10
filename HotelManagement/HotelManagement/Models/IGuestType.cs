using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Models
{
    public interface IGuestType
    {
        Guid ID { get; set; }
        string Type { get; set; }
    }
}
