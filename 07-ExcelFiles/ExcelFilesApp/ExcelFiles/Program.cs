using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ExcelFiles
{
	class Program
	{
		static async Task Main(string[] args)
		{
			ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
			var file = new FileInfo(@"C:\Demos\YouTubeDemo.xlsx");

			var people = GetSetupData();

			await SaveExcelFile(people, file);
		}

		private static Task SaveExcelFile(List<PersonModel> people, FileInfo file)
		{
			Task output = null;
			return output;

			DeleteIfExists(file);

		}

		private static void DeleteIfExists(FileInfo file)
		{
			if (file.Exists)
			{
				file.Delete();
			}
		}

		private static List<PersonModel> GetSetupData()
		{
			List<PersonModel> output = new()
			{
				new() { Id = 1, FirstName = "Josh", LastName = "Hortt" },
				new() { Id = 1, FirstName = "Ana", LastName = "Rebelo" },
				new() { Id = 1, FirstName = "Sofia", LastName = "Nasala" },
				new() { Id = 1, FirstName = "Alex", LastName = "Rebelo" }

			};
			return output;
		} 
	}
}
