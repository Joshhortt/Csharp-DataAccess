using DataAccessLibrary;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace SqliteUI
{
	class Program
	{
		static void Main(string[] args)
		{
            SqliteCrud sql = new SqliteCrud(GetConnectionString());

            // ReadAllContacts(sql);

            // ReadContact(sql, 3);

            // CreateNewContact(sql);

            // UpdateContact(sql);

            // RemovePhoneNumberFromContact(sql, 1, 1);

            Console.WriteLine("Processing Sqlite");

            Console.ReadLine();
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
