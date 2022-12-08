using System.Data.SqlClient;
using Models.Entities;
using Models.Interfaces.RepositoryInterfaces;

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
}