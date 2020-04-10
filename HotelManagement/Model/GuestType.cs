using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Models
{
    public class GuestType
    {
        public Guid ID { get; set; }
        public string Type { get; set; }
		public GuestType()
		{
		}
		public GuestType(string type)
		{
			Type = type;
		}
	}
}
