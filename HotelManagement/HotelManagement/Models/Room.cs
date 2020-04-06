using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
	public class Room: User
	{
		public Guid ID { get; set; }
		public int RoomNr { get; set; }
		public Guid RoomTypeID { get; set; }
		public string AditionalInfo { get; set; }
		public Guid TypeofAccommodationID { get; set; }
		public Room()
		{
		}
		public Room(int roomNr)
		{
			RoomNr = roomNr;
		}
	}
}
