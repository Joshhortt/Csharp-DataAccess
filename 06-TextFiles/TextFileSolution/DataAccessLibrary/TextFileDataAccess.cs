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
        public void WriteAllRecords(List<ContactModel> contacts, string textFile)
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