// Using statements
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefsDishes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ChefsDishes.Controllers;

public class ChefController : Controller
{
    private ChefsDishesContext _context;
    
    // here we can "inject" our context service into the constructor
    public ChefController( ChefsDishesContext context )
    {
        _context = context;
    }

    [ HttpGet("") ]
    public IActionResult Index()
    {
        List<Chef> AllChefs = _context.Chefs
        .Include( dish => dish.CreatedDishes )
        // .Include( chef => chef.FirstName )
        // .Include( chef => chef.LastName )
        // .Include(chef => chef.DateOfBirth)
        .ToList();
        return View( "AllChefs", AllChefs );
    }

    [ HttpGet( "new" ) ]
    public IActionResult ViewAddChef()
    {
        return View( "AddChef" );
    }

    [ HttpPost( "/chef/create" ) ]
    public IActionResult AddChef( Chef newChef )
    {
        _context.Chefs.Add( newChef );
        _context.SaveChanges();
        return RedirectToAction( "Index", "Chef" );
    }
}
