// 01 - C # Data Access - SQL Server

using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using DataAccessLibrary;
using DataAccessLibrary.Models;

namespace SQLServerUI
{
	class Program
	{
		static void Main(string[] args)
		{
			SqlCrud sql = new(GetConnectionString());

			// ReadAllContacts(sql);

			// ReadContact(sql, 1);

			CreateNewContact(sql);

		
			Console.ReadLine(); 
		}

		private static void CreateNewContact(SqlCrud sql)
		{
			FullContactModel user = new()
			{
				BasicInfo = new BasicContactModel
				{
					FirstName = "Ana",
					LastName = "Hortt"
				}
			};

			user.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "ana@gmail.com" });
			user.EmailAddresses.Add(new EmailAddressModel { Id = 2, EmailAddress = "jose@gmx.com" });

			user.PhoneNumbers.Add(new PhoneNumberModel { Id = 1, PhoneNumber = "911815877" });
			user.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "906122005" });

			sql.CreateContact(user);
		}

		private static void ReadAllContacts(SqlCrud sql)
		{
			var rows = sql.GetAllContacts();

			foreach(var row in rows)
			{
				Console.WriteLine($" { row.Id }: { row.FirstName } { row.LastName } ");
			}
		}

		private static void ReadContact(SqlCrud sql, int contactId)
		{
			var contact = sql.GetFullContactById(contactId);

				Console.WriteLine($" { contact.BasicInfo.Id }: { contact.BasicInfo.FirstName } { contact.BasicInfo.LastName } ");
			
		}

		private static string GetConnectionString(string connectionStringName = "Default")
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json");

			var config = builder.Build();
			string output = config.GetConnectionString(connectionStringName);
			return output;
		}
	}
}
