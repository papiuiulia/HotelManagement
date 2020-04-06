using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Models
{
	public class Reservation
	{

		public Guid ID { get; set; }
		public DateTime DateCreation { get; set; }
		public DateTime CheckIn { get; set; }
		public DateTime CheckOut { get; set; }
		public int NumberOfAdults { get; set; }
		public int NumberOfChildren { get; set; }
		public bool Meal { get; set; }
		public Guid ReservationTypeID { get; set; }
		public Guid GuestID { get; set; }
		public Guid RoomID { get; set; }
		public Reservation()
		{
		}
		public Reservation(int numberOfAdults)
		{
			NumberOfChildren = numberOfAdults;
		}
	}
}
