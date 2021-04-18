// C # Data Access - MySqlUI

using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace MySqlUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            MySqlCrud sql = new MySqlCrud(GetConnectionString());

            // To Tests Uncomment call methods below.

            // ReadAllContacts(sql);

            // ReadContact(sql, 3);

            // CreateNewContact(sql);

            // UpdateContact(sql);
            // ReadAllContacts(sql);

            //RemovePhoneNumberFromContact(sql, 1, 1);

            Console.WriteLine("Processing MySQL");

            Console.ReadLine();
        }

        private static void RemovePhoneNumberFromContact(MySqlCrud sql, int contactId, int phoneNumberId)
        {
            sql.RemovePhoneNumberFromContact(contactId, phoneNumberId);
        }

        private static void UpdateContact(MySqlCrud sql)
        {
            BasicContactModel contact = new BasicContactModel
            {
                Id = 1,
                FirstName = "Jose",
                LastName = "Horta"
            };
            sql.UpdateContactName(contact);
        }

        private static void CreateNewContact(MySqlCrud sql)
        {
            FullContactModel user = new FullContactModel
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

        private static void ReadAllContacts(MySqlCrud sql)
        {
            var rows = sql.GetAllContacts();

            foreach (var row in rows)
            {
                Console.WriteLine($"{ row.Id }: { row.FirstName } { row.LastName }");
            }
        }

        private static void ReadContact(MySqlCrud sql, int contactId)
        {
            var contact = sql.GetFullContactById(contactId);

            Console.WriteLine($"{ contact.BasicInfo.Id }: { contact.BasicInfo.FirstName } { contact.BasicInfo.LastName }");
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

