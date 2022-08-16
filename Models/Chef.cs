#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ChefsDishes.Models;

public class Chef
{
    [Key]
    public int ChefId { get; set; }

    [ Display( Name = "First Name" ) ]
    public string FirstName { get; set; } 

    [Display(Name = "Last Name")]
    public string LastName { get; set; } 

    [Display(Name = "Date Of Birth")]
    public DateTime DateOfBirth { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Dish> CreatedDishes { get; set; } = new List<Dish>();
    public string FullName()
    {
        return FirstName + " " + LastName;
    }

    public int Age()
    {
        return DateTime.Now.Year - DateOfBirth.Year;
    }

}