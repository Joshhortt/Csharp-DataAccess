using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace TextFileUI
{
	class Program
	{
        private static IConfiguration _config;
		private static string textFile;

		static void Main(string[] args)
		{
            InitializeConfiguration();

				textFile = _config.GetValue<string>("TextFile");

            Console.ReadLine();
		}

        private static void InitializeConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _config = builder.Build();
        }
    }
}
