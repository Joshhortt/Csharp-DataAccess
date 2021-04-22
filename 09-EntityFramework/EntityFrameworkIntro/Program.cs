﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

Console.WriteLine("Entity Framework!");

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

// 1. Create the DataBase Context
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