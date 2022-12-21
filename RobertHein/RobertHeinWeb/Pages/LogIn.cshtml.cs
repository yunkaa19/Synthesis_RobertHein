using System.Security.Claims;
using BusinessLogicLayer.Managers;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RobertHeinWeb.Pages;

public class LogIn : PageModel
{
    
    private CustomerManager _customerManager;

    public LogIn(ICustomerRepository customerRepository)
    {
        _customerManager = new CustomerManager(customerRepository);
    }
    public string ErrorMessage { get; private set; }
    public void OnGet()
    {
        
    }
    
    public async void Auth(string user)
    {
        var authProperties = new AuthenticationProperties
        {
            ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
        };
        
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user)
            
        };
        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            
        await HttpContext.SignInAsync(new ClaimsPrincipal(identity), authProperties);
    }

    public ActionResult OnPostLogin()
    {
        var email = Request.Form["email"];
        var password = Request.Form["password"];
        if (_customerManager.Login(email, password))
        {
            Auth(email);
            return RedirectToPage("/Index");
        }
        ErrorMessage = "Invalid credentials.";
        return Page();
    }
}