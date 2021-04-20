using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace MongoDbUI
{
	class Program
	{
        private static MongoDBDataAccess db;

        private static readonly string tableName = "Contacts";

		
		static void Main(string[] args)
		{
            db = new MongoDBDataAccess("MongoContactsDB", GetConnectionString());

            ContactModel user = new ContactModel
            {
                FirstName = "Josh",
                LastName = "Hortt"
            };
            user.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "joshhortt@yahoo.com" });
            user.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "jose@gmx.com" });
            user.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "911815877" });
            user.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "927916476" });

            CreateContact(user);


            Console.WriteLine("Done Processing MongoDB!");
            Console.ReadLine();
        }


		private static void CreateContact(ContactModel contact)
		{
			db.UpsertRecord(tableName, contact.Id, contact);
		}

		private static string GetConnectionString(string connectionStringName = "Default")
        {
            string output = "";

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            output = config.GetConnectionString(connectionStringName);

            return output;
        }
    }
}
