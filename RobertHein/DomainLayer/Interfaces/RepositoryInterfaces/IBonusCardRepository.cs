using Models.Entities;

namespace Models.Interfaces.RepositoryInterfaces;

public interface IBonusCardRepository
{
    bool DoesCardExist(string cardNumber);
    void AddBonusCard(BonusCard bonusCard);
    void UpdateBonusCard(BonusCard bonusCard);
    void DeleteBonusCard(BonusCard bonusCard);
}