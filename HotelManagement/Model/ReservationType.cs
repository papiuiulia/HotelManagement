using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Models
{
    public class ReservationType
    {
        public Guid ID { get; set; }
        public string Type { get; set; }
		public ReservationType()
		{
		}
		public ReservationType(string type)
		{
			Type = type;
		}
	}
}
