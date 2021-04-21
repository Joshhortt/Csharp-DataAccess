using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
	public class ContactModel
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public List<string> PhoneNumbers { get; set; } = new List<string>();  // Initialize List
		public List<string> EmailAddresses { get; set; } = new List<string>();  // Initialize List

	}
}
