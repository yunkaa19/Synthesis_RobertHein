using Models.Entities;

namespace Models.Interfaces.RepositoryInterfaces;

public interface IBonusRepository
{
    List<Bonuses> GetAllBonuses();
    Bonuses GetBonusById(int id);
    List<Bonuses> GetBonusesByProduct(Product product);
    List<Bonuses> GetBonusesByDate(DateOnly date);
    void AddBonus(Bonuses bonus);
    void UpdateBonus(Bonuses bonus);
    void DeleteBonus(Bonuses bonus);
    
}