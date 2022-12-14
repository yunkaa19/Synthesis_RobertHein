using Models.Entities;
using Models.Interfaces.RepositoryInterfaces;

namespace Models.Managers;

public class BonusCardManager
{
    private List<BonusCard> _bonusCards;
    private IBonusCardRepository _bonusCardRepository;
    
    public BonusCardManager(IBonusCardRepository bonusCardRepository)
    {
        _bonusCardRepository = bonusCardRepository;
        _bonusCards = _bonusCardRepository.GetAllBonusCards();
    }

    public void Refresh()
    {
        _bonusCards = _bonusCardRepository.GetAllBonusCards();
    }
    public void AddBonusCard(BonusCard bonusCard)
    {
        _bonusCards.Add(bonusCard);
        _bonusCardRepository.AddBonusCard(bonusCard);
    }
    
    public void RemovePointFromBonusCard(string bonusCardId, int points)
    {
        var bonusCard = _bonusCards.FirstOrDefault(b => b.CardNumber == bonusCardId);
        if (bonusCard != null)
        {
            bonusCard.RemoveBonusPoints(points);
            _bonusCardRepository.UpdateBonusCard(bonusCard);
        }
    }
    public void AddPointToBonusCard(string bonusCardId, int points)
    {
        var bonusCard = _bonusCards.FirstOrDefault(b => b.CardNumber == bonusCardId);
        if (bonusCard != null)
        {
            bonusCard.AddBonusPoints(points);
            _bonusCardRepository.UpdateBonusCard(bonusCard);
        }
    }

    public List<BonusCard> GenerateBonusCards(int amount)
    {
        List<BonusCard> NewBonusCards = _bonusCardRepository.GenerateBonusCards(amount);
        _bonusCards.AddRange(NewBonusCards);
        return NewBonusCards;
    }
}