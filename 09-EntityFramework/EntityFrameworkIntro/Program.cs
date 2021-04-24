using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

var factory = new CookbookContextFactory();
using var context = factory.CreateDbContext(args);

Console.WriteLine("Add Porridge to breakfast");

var porridge = new Dish { Title = "Breakfast Porridge", Notes = "This taste is amazing", Stars = 4 };
context.Dishes.Add(porridge);
await context.SaveChangesAsync();

// 1. ADD: Add First Record
//Console.WriteLine("Added Porridge successfully");  

// 2. ADD: Re-Add First Record with Id specification
Console.WriteLine($"Added Porridge (id = {porridge.Id }) successfully"); 

// 5. READ: Read Query +  Execute the Query
Console.WriteLine("Checking Stars for Porridge");
var dishes = await context.Dishes
	.Where(d => d.Title.Contains("Porridge")) //LINQ -> SQL- Ex: If we remove r from porridge and run, shows the message below. 
	.ToListAsync();
if (dishes.Count != 1) Console.Error.WriteLine("Something bad happened. Porridge dessapeared");
Console.WriteLine($"Porridge has { dishes[0].Stars} stars");


// 4. UPDATE: Update Stars
Console.WriteLine("Change Porridge Stars to 5");
porridge.Stars = 5;
await context.SaveChangesAsync();
Console.WriteLine("Updated Stars");

// 3. DELETE:  Remove porridge from database
//Console.WriteLine($"Added Porridge (id = {porridge.Id }) successfully");  
Console.WriteLine("Removing Porridge from database");
context.Dishes.Remove(porridge);  // removes porridge from db
await context.SaveChangesAsync();

Console.WriteLine("Porridge removed");

// 1. Create the Model classes
class Dish
{
	public int Id { get; set; }

	[MaxLength(100)]
	public string Title { get; set; } = string.Empty;

	[MaxLength(1000)]
	public string? Notes { get; set; }
	public int? Stars { get; set; }
	public List<DishIngredient> Ingredients { get; set; } = new();
}

class DishIngredient
{
	public int Id { get; set; }

	[MaxLength(100)]
	public string Description { get; set; } = string.Empty;

	[MaxLength(50)]
	public string UnitOfMeasure { get; set; } = string.Empty;

	[Column(TypeName = "decimal(5, 2)")]
	public decimal Amount{ get; set; }
	public Dish? Dish { get; set; }
	public int DishId { get; set; }
}

// 2. Create the DataBase Context
class CookbookContext : DbContext
{
	public DbSet<Dish> Dishes { get; set; }
	public DbSet<DishIngredient> Ingredients { get; set; }
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	public CookbookContext(DbContextOptions<CookbookContext> options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	{

	}
}

// 3. Create the Factory
class CookbookContextFactory : IDesignTimeDbContextFactory<CookbookContext>
{
	public CookbookContext CreateDbContext(string[] args)
	{
		var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

		var optionsBuilder = new DbContextOptionsBuilder<CookbookContext>();
		optionsBuilder
			// Uncomment the following line if you want to print generated
			// SQL statements on the console.
			.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
			.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);

		return new CookbookContext(optionsBuilder.Options);
	}
}
