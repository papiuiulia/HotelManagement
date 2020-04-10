using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Models
{
    public class AccommodationType
    {
            public Guid ID { get; set; }
            public string Type { get; set; }

		public AccommodationType()
		{
		}
		public AccommodationType(string type)
		{
			Type = type;
		}
	}
}