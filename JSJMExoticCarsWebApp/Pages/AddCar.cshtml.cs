using System.Text.Json;
using JSJMExoticCarsWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;



namespace JSJMExoticCarsWebApp.Pages;

public class addCar : PageModel
{
    [BindProperty]
    public Car Car { get; set; }
    
    public void OnGet()
    {
    }

    public void OnPost()
    {
    }
}

