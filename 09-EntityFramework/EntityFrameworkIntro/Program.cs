﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

Console.WriteLine("Entity Framework!");

// Create the Model classes
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