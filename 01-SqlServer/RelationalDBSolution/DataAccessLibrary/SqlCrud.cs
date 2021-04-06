using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
	public class SqlCrud
	{
		//  45. -- > 46. 
		private readonly string _connectionString;

		public SqlCrud(string connectionString)
		{
			_connectionString = connectionString;
		}

		public List<string> GetAllContacts()
		{

		}
	}
}
