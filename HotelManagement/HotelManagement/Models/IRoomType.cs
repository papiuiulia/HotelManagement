using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Models
{
    public interface IRoomType
    {
        Guid ID { get; set; }
        string Name { get; set; }
        decimal Price { get; set; }
    }
}
