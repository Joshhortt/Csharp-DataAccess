using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
	// Creating data 40. -- > 42.
	public class SqlDataAccess
	{
		public List<T> LoadData<T, U>(string sqlStatement, U parameters, string connectionString)
		{
			using (IDbConnection connection = new SqlConnection(connectionString))
			{ 
			List<T> rows = connection.Query<T>(sqlStatement, parameters).ToList();
			return rows;
			}
		}

		// Saving data 43. -- > 44.
		public void SaveData<T, U>(string sqlStatement, T parameters, string connectionString)
		{
			using (IDbConnection connection = new SqlConnection(connectionString))
			{
				connection.Execute(sqlStatement, parameters);
			}
		}
	}
}
