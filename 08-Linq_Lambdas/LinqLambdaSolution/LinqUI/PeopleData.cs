using LinqUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqUI
{
	public class PeopleData
	{
        public static List<ContactModel> GetContactData()
        {
            List<ContactModel> output = new List<ContactModel>
            {
                new ContactModel{ Id = 1, FirstName = "Josh", LastName = "Hortt", Addresses = new List<int>{1,2,3}},
                new ContactModel{ Id = 2, FirstName = "Ana", LastName = "Rebelo", Addresses = new List<int>{1}},
                new ContactModel{ Id = 3, FirstName = "Sofia", LastName = "Nasala", Addresses = new List<int>{2}},
                new ContactModel{ Id = 4, FirstName = "Alex", LastName = "Rebelo", Addresses = new List<int>{3}},
                new ContactModel{ Id = 5, FirstName = "Bruno", LastName = "Vieira", Addresses = new List<int>{2,3}}
            };

            return output;
        }

        public static List<AddressModel> GetAddressData()
        {
            List<AddressModel> output = new List<AddressModel>
            {
                new AddressModel{ Id = 1, ContactId = 1, City = "Lagos", Region = "Algarve"},
                new AddressModel{ Id = 2, ContactId = 1, City = "Beja", Region = "Baixo Alentejo"},
                new AddressModel{ Id = 3, ContactId = 2, City = "Albufeira", Region = "Algarve"},
                new AddressModel{ Id = 4, ContactId = 5, City = "Vilamoura", Region = "Algarve"},
                new AddressModel{ Id = 5, ContactId = 5, City = "Lisboa", Region = "Estremadura"},
                new AddressModel{ Id = 6, ContactId = 4, City = "Amadora", Region = "Estremadura"},
                new AddressModel{ Id = 7, ContactId = 3, City = "Santarem", Region = "Ribatejo"}
            };

            return output;
        }
    }
}
