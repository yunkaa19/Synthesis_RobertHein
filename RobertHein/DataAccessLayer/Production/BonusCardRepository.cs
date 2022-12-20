using System.Data.SqlClient;
using DataAccessLayer.Interfaces;
using Models.Entities;
 

namespace DataAccessLayer.Production;

public class BonusCardRepository: Repository, IBonusCardRepository
{
    public bool DoesCardExist(string cardNumber)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM BonusCards WHERE CardNumber = @cardNumber", connection);
                command.Parameters.AddWithValue("@cardNumber", cardNumber);
                int count = (int)command.ExecuteScalar();
                if (count == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        catch (Exception e)
        {
            
        }

        return false;
    }

    public void AddBonusCard(BonusCard bonusCard)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO BonusCards (Points) VALUES (0)", connection);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception e)
        {
            
        }
    }

    public List<BonusCard> GenerateBonusCards(int amount)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("INSERT INTO BonusCards (Points) VALUES (0)", connection);
                for (int i = 0; i < amount; i++)
                {
                    command.ExecuteNonQuery();
                }
                SqlCommand command2 = new SqlCommand("SELECT TOP " + amount + " * FROM BonusCards ORDER BY CardNumber DESC", connection);
                SqlDataReader reader = command2.ExecuteReader();
                List<BonusCard> bonusCards = new List<BonusCard>();
                while (reader.Read())
                {
                    string CardNumber = reader["CardNumber"].ToString();
                    int Points = Convert.ToInt32(reader["Points"]);
                    bonusCards.Add(new BonusCard(CardNumber, Points));
                }
                return bonusCards;
            }   
        }
        catch (Exception e)
        {
            
        }

        return null!;
    }

    public void UpdateBonusCard(BonusCard bonusCard)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE BonusCards SET Points = @points WHERE CardNumber = @cardNumber", connection);
                command.Parameters.AddWithValue("@points", bonusCard.BonusPoints);
                command.Parameters.AddWithValue("@cardNumber", bonusCard.CardNumber);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception e)
        {
            
        }
    }

    public void DeleteBonusCard(BonusCard bonusCard)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM BonusCards WHERE CardNumber = @cardNumber", connection);
                command.Parameters.AddWithValue("@cardNumber", bonusCard.CardNumber);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception e)
        {
            
        }
    }

    public BonusCard GetBonusCard(string cardNumber)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM BonusCards WHERE CardNumber = @cardNumber", connection);
                command.Parameters.AddWithValue("@cardNumber", cardNumber);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    string CardNumber = reader["CardNumber"].ToString();
                    int Points = Convert.ToInt32(reader["Points"]);
                    return new BonusCard(CardNumber, Points);
                }
            }
        }
        catch (Exception e)
        {
            
        }

        return null!;
    }

    public List<BonusCard> GetAllBonusCards()
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM BonusCards", connection);
                SqlDataReader reader = command.ExecuteReader();
                List<BonusCard> bonusCards = new List<BonusCard>();
                while (reader.Read())
                {
                    string CardNumber = reader["CardNumber"].ToString();
                    int Points = Convert.ToInt32(reader["Points"]);
                    bonusCards.Add(new BonusCard(CardNumber, Points));
                }
                return bonusCards;
            }
        }
        catch (Exception e)
        {
            
        }

        return null!;
    }
}