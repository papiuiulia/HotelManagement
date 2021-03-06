﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HotelManagement.Models
{
	public class Guest
	{
		public Guid ID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }
		public string City { get; set; }
		public string Country { get; set; }
		public Guid GuestTypeID { get; set; }
		public string AditionalInfo { get; set; }

		public Guest()
		{
		}
		public Guest(string firstName)
		{
			FirstName = firstName;
		}
	}
}