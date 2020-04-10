using System;

namespace Model
{
	public class Room: User
	{
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
