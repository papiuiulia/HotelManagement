using System;

namespace HotelManagement.Models

public class Guest
{
	public Guest()
	{
	public int GuestID { get; set; }

	public string FirstName { get; set; }

	public string LastName { get; set; }

	public string Email { get; set; }

	public string Phone { get; set; }

	public string Address { get; set; }

	public string City { get; set; }

	public string Country { get; set; }

	public int GuestTypeID { get; set; }

	public string AditionalInfo { get; set; }
}
}
