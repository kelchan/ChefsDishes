// Using statements
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsDishes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ChefsDishes.Controllers;

public class DishController : Controller
{
    private ChefsDishesContext _context;
    
    // here we can "inject" our context service into the constructor
    public DishController( ChefsDishesContext context )
    {
        _context = context;
    }

    [ HttpGet( "dishes" ) ]
    public IActionResult AllDishes()
    {
        List<Dish> EveryDish = _context.Dishes.Include( c => c.Cook ).ToList();
        ViewBag.AllDishes = EveryDish; 
        return View( "AllDishes", EveryDish );
    }

    [ HttpGet( "/dishes/new" ) ]
    public IActionResult ViewAddDish()
    {
        ViewBag.AllChefs = _context.Chefs.ToList();
        return View( "AddDish" );
    }

    [ HttpPost( "/dish/create" ) ]
    public IActionResult AddDish( Dish newDish )
    {
        newDish.ChefId = newDish.ChefId;
        _context.Dishes.Add( newDish );
        _context.SaveChanges();
        return RedirectToAction( "AllDishes", "Dish" );
    }

}