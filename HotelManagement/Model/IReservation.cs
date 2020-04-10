using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Models
{
    public interface IReservation
    {
		Guid ID { get; set; }
		DateTime DateCreation { get; set; }
		DateTime CheckIn { get; set; }
		DateTime CheckOut { get; set; }
		int NumberOfAdults { get; set; }
		int NumberOfChildren { get; set; }
		bool Meal { get; set; }
	    Guid ReservationTypeID { get; set; }
		Guid GuestID { get; set; }
		Guid RoomID { get; set; }
	}
}
