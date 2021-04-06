using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
	public class SqlCrud
	{ 
		private readonly string _connectionString;
		private readonly SqlDataAccess db = new();

		public SqlCrud(string connectionString)
		{
			_connectionString = connectionString;
		}

		public List<BasicContactModel> GetAllContacts()
		{
			string sql = "select Id, FirstName, LastName from dbo.Contacts";

			return db.LoadData<BasicContactModel, dynamic>(sql, new { }, _connectionString);
		}

		public BasicContactModel GetFullContactsById(int id)
		{
			string sql = "select Id, FirstName, LastName from dbo.Contacts where Id = @Id";
			FullContactModel output = new FullContactModel();

			output.BasicInfo = db.LoadData<BasicContactModel, dynamic>(sql, new { Id = id }, _connectionString).FirstOrDefault();
			if(output.BasicInfo == null)
			{
				//Do something to tell the user that the record was not found
				return null;
			}
		}
	}
}
