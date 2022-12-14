namespace Models.Entities;

public class BonusCard
{

    private readonly string _cardNumber;
    private int _bonusPoints;
    
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
    
    public void AddBonusPoints(int bonuspoints)
    {
        _bonusPoints += bonuspoints;
    }
    public void RemoveBonusPoints(int bonuspoints)
    {
        _bonusPoints -= bonuspoints;
    }
    
}