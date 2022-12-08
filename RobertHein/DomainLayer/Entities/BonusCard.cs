namespace Models.Entities;

public class BonusCard
{

    private readonly string _cardNumber;
    private readonly int _bonusPoints;
    
    public string CardNumber
    {
        get => _cardNumber;
    }
    public int BonusPoints
    {
        get => _bonusPoints;
    }
    
    
    public BonusCard(string cardnumber, int bonuspoints)
    {
        
        _cardNumber = cardnumber.Substring(0,7);
        _bonusPoints = bonuspoints;
    }
    
    
    // public List<BonusCard> GenerateBonusCards(int amount) TODO: Come up with a working way to generate bonus cards
    // {
    //     var bonusCards = new List<BonusCard>();
    //     for (int i = 0; i < amount; i++)
    //     {
    //         bonusCards.Add(new BonusCard());
    //     }
    //     return bonusCards;
    // }
}