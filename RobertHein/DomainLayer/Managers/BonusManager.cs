﻿using Models.Entities;
using Models.Interfaces.RepositoryInterfaces;

namespace Models.Managers;

public class BonusManager
{
    List<Bonuses> _bonuses;
    IBonusRepository _bonusRepository;
    
    public BonusManager(IBonusRepository bonusRepository)
    {
        _bonusRepository = bonusRepository;
        _bonuses = _bonusRepository.GetAllBonuses();
    }

    public void Refresh()
    {
        _bonuses = _bonusRepository.GetAllBonuses();
    }
    
    public Bonuses GetBonusById(int id)
    {
        if(_bonuses.Any(b => b.Id == id))
        {
            return _bonuses.First(b => b.Id == id);
        }
        else
        {
            return _bonusRepository.GetBonusById(id);
        }
    }

    public List<Bonuses> GetBonusesByProduct(Product product)
    {
        List<Bonuses> bonuses;
        bonuses = _bonuses.Where(b => b.Product.Id == product.Id).ToList();
        if(bonuses.Count == 0)
        {
            bonuses = _bonusRepository.GetBonusesByProduct(product);
        }
        return bonuses;
    }

    public List<Bonuses> GetBonusesByDate(DateOnly date)
    {
        List<Bonuses> bonuses;
        bonuses = _bonuses.Where(b => b.StartDate <= date && b.EndDate >= date).ToList();
        if(bonuses.Count == 0)
        {
            bonuses = _bonusRepository.GetBonusesByDate(date);
        }
        return bonuses;
    }
    public void AddBonus(Bonuses bonus)
    {
        _bonusRepository.AddBonus(bonus);
        Refresh();
    }
    public void UpdateBonus(Bonuses bonus)
    {
        _bonusRepository.UpdateBonus(bonus);
        Refresh();
    }
    public void DeleteBonus(Bonuses bonus)
    {
        _bonusRepository.DeleteBonus(bonus);
        _bonuses.Remove(bonus);
    }
}