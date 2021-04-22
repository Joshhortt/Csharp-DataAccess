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

		private static async Task SaveExcelFile(List<PersonModel> people, FileInfo file)
		{
			DeleteIfExists(file);

			using var package = new ExcelPackage(file);  // Create excel file

			var ws = package.Workbook.Worksheets.Add("MainReport");  // Add new Worksheet

			var range = ws.Cells["A1"].LoadFromCollection(people, true);  // Start at cell A1 (Upper left). Load from people List into the file

			range.AutoFitColumns();  // fit into the right widths/heights of the column

			await package.SaveAsync();  // Saves asynchronously the file
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
