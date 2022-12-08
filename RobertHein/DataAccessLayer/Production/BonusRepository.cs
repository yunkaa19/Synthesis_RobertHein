using Models.Entities;
using Models.Interfaces.RepositoryInterfaces;

namespace DataAccessLayer.Production;

public class BonusRepository :Repository, IBonusRepository
{
    public List<Bonus> GetAllBonuses()
    {
        throw new NotImplementedException();
    }

    public Bonus GetBonusById(int id)
    {
        throw new NotImplementedException();
    }

    public Bonus GetBonusByProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public List<Bonus> GetBonusesByDate(DateOnly date)
    {
        throw new NotImplementedException();
    }

    public void AddBonus(Bonus bonus)
    {
        throw new NotImplementedException();
    }

    public void UpdateBonus(Bonus bonus)
    {
        throw new NotImplementedException();
    }

    public void DeleteBonus(Bonus bonus)
    {
        throw new NotImplementedException();
    }
}