using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class TextFileDataAccess
    {
        // READ ALL RECORDS
        public static List<ContactModel> ReadAllRecords(string textFile)
        {
            if (File.Exists(textFile) == false)
            {
                return new List<ContactModel>();
            }

            var lines = File.ReadAllLines(textFile);
            List<ContactModel> output = new List<ContactModel>();

            foreach (var line in lines)
            {
                ContactModel c = new ContactModel();
                var values = line.Split(',');

                if (values.Length < 4)
                {
                    throw new Exception($"This a Invalid row of data: { line }");
                }

                c.FirstName = values[0];
                c.LastName = values[1];
                c.EmailAddresses = values[2].Split(';').ToList();
                c.PhoneNumbers = values[3].Split(';').ToList();

                output.Add(c);
            }

            return output;
        }

        // WRITE ALL RECORDS
        public static void WriteAllRecords(List<ContactModel> contacts, string textFile)
        {
            List<string> lines = new List<string>();

			foreach (var c in contacts)
			{
				lines.Add($"{ c.FirstName },{ c.LastName },{ String.Join(';', c.EmailAddresses) },{ String.Join(';', c.PhoneNumbers) }");
			}

			File.WriteAllLines(textFile, lines);
		}
    }
}