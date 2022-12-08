using Models.Entities;

namespace Models.Interfaces.RepositoryInterfaces;

public interface IBonusRepository
{
    List<Bonus> GetAllBonuses();
    Bonus GetBonusById(int id);
    Bonus GetBonusByProduct(Product product);
    List<Bonus> GetBonusesByDate(DateOnly date);
    void AddBonus(Bonus bonus);
    void UpdateBonus(Bonus bonus);
    void DeleteBonus(Bonus bonus);
    
}