using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Models
{
    public class RoomType
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
		public RoomType()
		{
		}
		public RoomType(string name)
		{
			Name = name;
		}
	}
}
