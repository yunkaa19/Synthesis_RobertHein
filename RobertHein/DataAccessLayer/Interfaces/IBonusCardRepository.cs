using Models.Entities;

namespace DataAccessLayer.Interfaces;

public interface IBonusCardRepository
{
    bool DoesCardExist(string cardNumber);
    void AddBonusCard(BonusCard bonusCard);
    public List<BonusCard> GenerateBonusCards(int amount);
    void UpdateBonusCard(BonusCard bonusCard);
    void DeleteBonusCard(BonusCard bonusCard);
    BonusCard GetBonusCard(string cardNumber);
    List<BonusCard> GetAllBonusCards();
}