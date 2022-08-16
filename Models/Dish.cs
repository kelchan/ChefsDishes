#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ChefsDishes.Models;

public class Dish
{
    [Key]
    public int DishId { get; set; }

    [ Required( ErrorMessage = "is required" ) ]
    [ Display( Name = "Name" ) ]
    public string Name { get; set; }

    [ Required( ErrorMessage = "is required" ) ]
    [ Display( Name = "# of Calories" ) ]
    public int NumOfCalories { get; set; } 

    [ Required( ErrorMessage = "is required" ) ]
    [ Display( Name = "Description" ) ]
    public string Description { get; set; }

    [ Required( ErrorMessage = "is required" ) ]
    [ Display( Name = "Tastiness" ) ]
    public int Tastiness { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    [ Required( ErrorMessage = "is required" ) ]
    [ Display( Name = "Chef" ) ]
    public int ChefId { get; set; }
    public Chef? Cook { get; set; }


}