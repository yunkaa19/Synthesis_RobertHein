using System.Security.Claims;
using BusinessLogicLayer;
using BusinessLogicLayer.Managers;
using DataAccessLayer.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models.DTO;

namespace RobertHeinWeb.Pages;

public class RegisterPage : PageModel
{
    private CustomerManager _customerManager;
    public RegisterPage(ICustomerRepository customerRepository)
    {
        _customerManager = new CustomerManager(customerRepository);
    }
    
    [BindProperty] public Register customerRegister { get; set; }
    
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

    public ActionResult OnPostRegister()
    {
        if (ModelState.IsValid)
        {
            customerRegister.password = PasswordHasher.HashPassword(customerRegister.password);
            if (!_customerManager.AddCustomer(customerRegister))
            {
                ErrorMessage = "Email already exists";
                return Page();
            }
            Auth(customerRegister.email);
            return RedirectToPage("/Index");
        }
        
        
        return Page();
    }
}