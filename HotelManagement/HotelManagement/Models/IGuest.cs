using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Models
{
    public interface IGuest
    {
        Guid ID { get; set; }
        string FirstName { get; set; }
		string LastName { get; set; }
		string Email { get; set; }
		string Phone { get; set; }
		string Address { get; set; }
		string City { get; set; }
		string Country { get; set; }
		Guid GuestTypeID { get; set; }
		string AditionalInfo { get; set; }
	}
}
