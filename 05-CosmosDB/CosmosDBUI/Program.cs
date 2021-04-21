using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CosmosDBUI
{
    class Program
    {
        private static CosmosDBDataAccess db;

        static async Task Main(string[] args)
        {
            var c = GetCosmosInfo();

            db = new CosmosDBDataAccess(c.endpointUrl, c.primaryKey, c.databaseName, c.containerName);

            ContactModel user = new ContactModel
            {
                FirstName = "Josh",
                LastName = "Hortt"
            };

            user.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "joshhortt@yahoo.com" });
            user.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "jose@gmx.com" });
            user.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "911815877" });
            user.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "927916476" });

            ContactModel user2 = new ContactModel
            {
                FirstName = "Ana",
                LastName = "Rebelo"
            };

            user2.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "ana@gmx.com" });
            user2.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "jose@gmx.com" });
            user2.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "911815877" });
            user2.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "906122005" });

            //await CreateContact(user);
            //await CreateContact(user2);

            //await GetAllContacts();

            //0b6e24b3-95ab-4c77-9198-dbf6d9cc1e7c
            //await GetContactById("0b6e24b3-95ab-4c77-9198-dbf6d9cc1e7c");

            //await UpdateContactsFirstName("Jose", "0b6e24b3-95ab-4c77-9198-dbf6d9cc1e7c");
            //await GetContactById("0b6e24b3-95ab-4c77-9198-dbf6d9cc1e7c");

            //await RemovePhoneNumberFromUser("555-1212", "0b6e24b3-95ab-4c77-9198-dbf6d9cc1e7c");

            //await RemoveUser("0b6e24b3-95ab-4c77-9198-dbf6d9cc1e7c", "Hortt");

            Console.WriteLine("Done Processing CosmosDB");
            Console.ReadLine();
        }

        public static async Task RemoveUser(string id, string lastName)
        {
            await db.DeleteRecordAsync<ContactModel>(id, lastName);
        }

        public static async Task RemovePhoneNumberFromUser(string phoneNumber, string id)
        {
            var contact = await db.LoadRecordByIdAsync<ContactModel>(id);

            contact.PhoneNumbers = contact.PhoneNumbers.Where(x => x.PhoneNumber != phoneNumber).ToList();

            await db.UpsertRecordAsync(contact);
        }

        private static async Task UpdateContactsFirstName(string firstName, string id)
        {
            var contact = await db.LoadRecordByIdAsync<ContactModel>(id);

            contact.FirstName = firstName;

            await db.UpsertRecordAsync(contact);
        }

        private static async Task GetContactById(string id)
        {
            var contact = await db.LoadRecordByIdAsync<ContactModel>(id);
            Console.WriteLine($"{ contact.Id}: { contact.FirstName } { contact.LastName }");
        }

        private static async Task GetAllContacts()
        {
            var contacts = await db.LoadRecordsAsync<ContactModel>();

            foreach (var contact in contacts)
            {
                Console.WriteLine($"{ contact.Id}: { contact.FirstName } { contact.LastName }");
            }
        }

        private static async Task CreateContact(ContactModel contact)
        {
            await db.UpsertRecordAsync(contact);
        }

        private static (string endpointUrl, string primaryKey, string databaseName, string containerName) GetCosmosInfo()
        {
            (string endpointUrl, string primaryKey, string databaseName, string containerName) output;

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            output.endpointUrl = config.GetValue<string>("CosmosDB:EndpointUrl");
            output.primaryKey = config.GetValue<string>("CosmosDB:PrimaryKey");
            output.databaseName = config.GetValue<string>("CosmosDB:DatabaseName");
            output.containerName = config.GetValue<string>("CosmosDB:ContainerName");

            return output;
        }
    }
}
