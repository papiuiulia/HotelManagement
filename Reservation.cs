using System;

namespace HotelManagement.Models

public class Reservation
{
	public Reservation()
	{
	public DateTime DateCreation { get; set; }

	public DateTime CheckIn { get; set; }

	public DateTime CheckOut { get; set; }

	public int NumberOfAdults { get; set; }

	public int NumberOfChildren { get; set; }

	public string Meal { get; set; }

	public int ReservationID { get; set; }

	public int ReservationTypeID { get; set; }

	public int GuestID { get; set; }

	public int RoomID { get; set; }
}
}
