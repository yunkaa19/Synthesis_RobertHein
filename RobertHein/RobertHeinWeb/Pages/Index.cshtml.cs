using BusinessLogicLayer.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Models;
using Models.Entities.Bonus;

namespace RobertHeinWeb.Pages;

public class IndexModel : PageModel
{
    public BonusManager _bonusManager;
    
    
    public IndexModel(IBonusRepository bonusRepository)
    {
        _bonusManager = new BonusManager(bonusRepository);
    }
    
    
    
    // private readonly ILogger<IndexModel> _logger;
    //
    // public IndexModel(ILogger<IndexModel> logger)
    // {
    //     _logger = logger;
    // }

    public void OnGet()
    {

    }
}
