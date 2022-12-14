using System.Data.SqlClient;
using Models.Entities;
using Models.Enums;
using Models.Interfaces.RepositoryInterfaces;

namespace DataAccessLayer.Production;

public class BonusRepository :Repository, IBonusRepository
{
    public List<Bonuses> GetAllBonuses()
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select p.ProductID, Name, p.Price, U.Unit, UnitExtension, InStock, Discontinued, image, C.CategoryID, CategoryName,ParentID, BonusID, StartDate, EndDate, B.Price, TypeOfBonus, percentage, quantity, xAmount from Products as p join Categories as C on p.CategoryID = C.CategoryID join Units as U on p.Unit = U.ID join Bonuses B on p.ProductID = B.ProductID join TypesOfBonuses TOB on B.BonusID = TOB.Id ", connection);
                SqlDataReader reader = command.ExecuteReader();
                List<Bonuses> bonuses = new List<Bonuses>();
                while (reader.Read())
                {
                    int productId = Convert.ToInt32(reader["ProductID"]);
                    string productName = reader["Name"].ToString();
                    float productPrice = (float)Convert.ToDouble(reader["Price"]);
                    Units unit = (Units)Convert.ToInt32(reader["Unit"]);
                    string unitExtension = "";
                    if(reader["UnitExtension"] != DBNull.Value)
                    {
                        unitExtension = reader["UnitExtension"].ToString();
                    }
                    int inStock = Convert.ToInt32(reader["InStock"]);
                    bool discontinued = Convert.ToBoolean(reader["Discontinued"]);
                    byte[] image = (byte[])reader["image"];
                    int categoryId = Convert.ToInt32(reader["CategoryID"]);
                    string categoryName = reader["CategoryName"].ToString();
                    int categoryParent = -1;
                    if (reader["ParentID"] != DBNull.Value)
                    {
                        categoryParent = Convert.ToInt32(reader["ParentID"]);
                    }
                    int bonusId = Convert.ToInt32(reader["BonusID"]);
                    DateOnly startDate = (DateOnly)reader["StartDate"];
                    DateOnly endDate = (DateOnly)reader["EndDate"];
                    float bonusPrice = (float)Convert.ToDouble(reader["Price"]);
                    BonusType typeOfBonus = (BonusType)Convert.ToInt32(reader["TypeOfBonus"]);
                    int percentage = -1;
                    if (reader["percentage"] != DBNull.Value)
                    {
                        percentage = Convert.ToInt32(reader["percentage"]);
                    }
                    int quantity = -1;
                    if (reader["quantity"] != DBNull.Value)
                    {
                        quantity = Convert.ToInt32(reader["quantity"]);
                    }
                    int xAmount =-1;
                    if (reader["xAmount"] != DBNull.Value)
                    {
                        xAmount = Convert.ToInt32(reader["xAmount"]);
                    }

                    Category category;
                    if (categoryParent != -1)
                    {
                        category = new Category(categoryId, categoryName, categoryParent);
                    }
                    else
                    {
                        category = new Category(categoryId, categoryName);
                    }

                    Product product;
                    if (String.IsNullOrEmpty(unitExtension))
                    {
                        product = new Product(productId, category, productName, productPrice, inStock, unit, image, discontinued);
                    }
                    else
                    {
                        product = new Product(productId, category, productName, productPrice, inStock, unit, unitExtension, image, discontinued);
                    }
                    
                    if (typeOfBonus == BonusType.Percentage)
                    {
                        PercentageDiscount percentageDiscount = new PercentageDiscount(bonusId, product, startDate, endDate, bonusPrice, percentage);
                        bonuses.Add(percentageDiscount);
                    }
                    else if (typeOfBonus == BonusType.Quantity)
                    {
                        QuantityDiscount quantityDiscount = new QuantityDiscount(bonusId, product, startDate, endDate, bonusPrice, quantity);
                        bonuses.Add(quantityDiscount);
                    }
                    else if (typeOfBonus == BonusType.SecondHalfPrice)
                    {
                        SecondHalfPrice secondHalfPrice = new SecondHalfPrice(bonusId, product, startDate, endDate, bonusPrice);
                        bonuses.Add(secondHalfPrice);
                    }
                    else if (typeOfBonus == BonusType.XForY)
                    {
                        XForThePriceOfY xForY = new XForThePriceOfY(bonusId, product, startDate, endDate, bonusPrice, xAmount);
                        bonuses.Add(xForY);
                    }
                }

                return bonuses;
            }
        }
        catch (Exception ex)
        {
            
        }

        return null;
    }

    public Bonuses GetBonusById(int id)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select p.ProductID, Name, p.Price, U.Unit, UnitExtension, InStock, Discontinued, image, C.CategoryID, CategoryName,ParentID, BonusID, StartDate, EndDate, B.Price, TypeOfBonus, percentage, quantity, xAmount from Products as p join Categories as C on p.CategoryID = C.CategoryID join Units as U on p.Unit = U.ID join Bonuses B on p.ProductID = B.ProductID join TypesOfBonuses TOB on B.BonusID = TOB.Id where BonusID = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = command.ExecuteReader();
                Bonuses bonus = null;
                if (reader.Read())
                {
                    int productId = Convert.ToInt32(reader["ProductID"]);
                    string productName = reader["Name"].ToString();
                    float productPrice = (float)Convert.ToDouble(reader["Price"]);
                    Units unit = (Units)Convert.ToInt32(reader["Unit"]);
                    string unitExtension = "";
                    if(reader["UnitExtension"] != DBNull.Value)
                    {
                        unitExtension = reader["UnitExtension"].ToString();
                    }
                    int inStock = Convert.ToInt32(reader["InStock"]);
                    bool discontinued = Convert.ToBoolean(reader["Discontinued"]);
                    byte[] image = (byte[])reader["image"];
                    int categoryId = Convert.ToInt32(reader["CategoryID"]);
                    string categoryName = reader["CategoryName"].ToString();
                    int categoryParent = -1;
                    if (reader["ParentID"] != DBNull.Value)
                    {
                        categoryParent = Convert.ToInt32(reader["ParentID"]);
                    }
                    int bonusId = Convert.ToInt32(reader["BonusID"]);
                    DateOnly startDate = (DateOnly)reader["StartDate"];
                    DateOnly endDate = (DateOnly)reader["EndDate"];
                    float bonusPrice = (float)Convert.ToDouble(reader["Price"]);
                    BonusType typeOfBonus = (BonusType)Convert.ToInt32(reader["TypeOfBonus"]);
                    int percentage = -1;
                    if (reader["percentage"] != DBNull.Value)
                    {
                        percentage = Convert.ToInt32(reader["percentage"]);
                    }
                    int quantity = -1;
                    if (reader["quantity"] != DBNull.Value)
                    {
                        quantity = Convert.ToInt32(reader["quantity"]);
                    }
                    int xAmount =-1;
                    if (reader["xAmount"] != DBNull.Value)
                    {
                        xAmount = Convert.ToInt32(reader["xAmount"]);
                    }

                    Category category;
                    if (categoryParent != -1)
                    {
                        category = new Category(categoryId, categoryName, categoryParent);
                    }
                    else
                    {
                        category = new Category(categoryId, categoryName);
                    }

                    Product product;
                    if (String.IsNullOrEmpty(unitExtension))
                    {
                        product = new Product(productId, category, productName, productPrice, inStock, unit, image, discontinued);
                    }
                    else
                    {
                        product = new Product(productId, category, productName, productPrice, inStock, unit, unitExtension, image, discontinued);
                    }
                    
                    if (typeOfBonus == BonusType.Percentage)
                    {
                        PercentageDiscount percentageDiscount = new PercentageDiscount(bonusId, product, startDate, endDate, bonusPrice, percentage);
                        bonus = percentageDiscount;
                    }
                    else if (typeOfBonus == BonusType.Quantity)
                    {
                        QuantityDiscount quantityDiscount = new QuantityDiscount(bonusId, product, startDate, endDate, bonusPrice, quantity);
                        bonus = quantityDiscount;
                    }
                    else if (typeOfBonus == BonusType.SecondHalfPrice)
                    {
                        SecondHalfPrice secondHalfPrice = new SecondHalfPrice(bonusId, product, startDate, endDate, bonusPrice);
                        bonus = secondHalfPrice;
                    }
                    else if (typeOfBonus == BonusType.XForY)
                    {
                        XForThePriceOfY xForY = new XForThePriceOfY(bonusId, product, startDate, endDate, bonusPrice, xAmount);
                        bonus = xForY;
                    }
                    
                }
                return bonus;
            }

            
        }
        catch (Exception ex)
        {
            
        }

        return null!;
    }

    public List<Bonuses> GetBonusesByProduct(Product product)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select * from Bonuses where ProductID = @ProductID", connection);
                command.Parameters.AddWithValue("@ProductID", product.Id);
                SqlDataReader reader = command.ExecuteReader();
                List<Bonuses> bonuses = new List<Bonuses>();
                while (reader.Read())
                {
                    int bonusId = Convert.ToInt32(reader["BonusID"]);
                    DateOnly startDate = (DateOnly)reader["StartDate"];
                    DateOnly endDate = (DateOnly)reader["EndDate"];
                    float bonusPrice = (float)Convert.ToDouble(reader["Price"]);
                    BonusType typeOfBonus = (BonusType)Convert.ToInt32(reader["TypeOfBonus"]);
                    int percentage = -1;
                    if (reader["percentage"] != DBNull.Value)
                    {
                        percentage = Convert.ToInt32(reader["percentage"]);
                    }
                    int quantity = -1;
                    if (reader["quantity"] != DBNull.Value)
                    {
                        quantity = Convert.ToInt32(reader["quantity"]);
                    }
                    int xAmount = -1;
                    if (reader["xAmount"] != DBNull.Value)
                    {
                        xAmount = Convert.ToInt32(reader["xAmount"]);
                    }

                    if (typeOfBonus == BonusType.Percentage)
                    {
                        PercentageDiscount percentageDiscount = new PercentageDiscount(bonusId, product, startDate, endDate, bonusPrice, percentage);
                        bonuses.Add(percentageDiscount);
                    }
                    else if (typeOfBonus == BonusType.Quantity)
                    {
                        QuantityDiscount quantityDiscount = new QuantityDiscount(bonusId, product, startDate, endDate, bonusPrice, quantity);
                        bonuses.Add(quantityDiscount);
                    }
                    else if (typeOfBonus == BonusType.SecondHalfPrice)
                    {
                        SecondHalfPrice secondHalfPrice = new SecondHalfPrice(bonusId, product, startDate, endDate, bonusPrice);
                        bonuses.Add(secondHalfPrice);
                    }
                    else if (typeOfBonus == BonusType.XForY)
                    {
                        XForThePriceOfY xForY = new XForThePriceOfY(bonusId, product, startDate, endDate, bonusPrice, xAmount);
                        bonuses.Add(xForY);
                    }
                }
                return bonuses;
            }
        }
        catch (Exception ex)
        {
            
        }

        return null!;
    }

    public List<Bonuses> GetBonusesByDate(DateOnly date)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("p.ProductID, Name, p.Price, U.Unit, UnitExtension, InStock, Discontinued, image, C.CategoryID, CategoryName,ParentID, BonusID, StartDate, EndDate, B.Price, TypeOfBonus, percentage, quantity, xAmount from Products as p join Categories as C on p.CategoryID = C.CategoryID join Units as U on p.Unit = U.ID join Bonuses B on p.ProductID = B.ProductID join TypesOfBonuses TOB on B.BonusID = TOB.Id where StartDate <= @Date and EndDate >= @Date", connection);
                command.Parameters.AddWithValue("@Date", date);             
                SqlDataReader reader = command.ExecuteReader();
                List<Bonuses> bonuses = new List<Bonuses>();
                while (reader.Read())
                {
                    int productId = Convert.ToInt32(reader["ProductID"]);
                    string productName = reader["Name"].ToString();
                    float productPrice = (float)Convert.ToDouble(reader["Price"]);
                    Units unit = (Units)Convert.ToInt32(reader["Unit"]);
                    string unitExtension = "";
                    if(reader["UnitExtension"] != DBNull.Value)
                    {
                        unitExtension = reader["UnitExtension"].ToString();
                    }
                    int inStock = Convert.ToInt32(reader["InStock"]);
                    bool discontinued = Convert.ToBoolean(reader["Discontinued"]);
                    byte[] image = (byte[])reader["image"];
                    int categoryId = Convert.ToInt32(reader["CategoryID"]);
                    string categoryName = reader["CategoryName"].ToString();
                    int categoryParent = -1;
                    if (reader["ParentID"] != DBNull.Value)
                    {
                        categoryParent = Convert.ToInt32(reader["ParentID"]);
                    }
                    int bonusId = Convert.ToInt32(reader["BonusID"]);
                    DateOnly startDate = (DateOnly)reader["StartDate"];
                    DateOnly endDate = (DateOnly)reader["EndDate"];
                    float bonusPrice = (float)Convert.ToDouble(reader["Price"]);
                    BonusType typeOfBonus = (BonusType)Convert.ToInt32(reader["TypeOfBonus"]);
                    int percentage = -1;
                    if (reader["percentage"] != DBNull.Value)
                    {
                        percentage = Convert.ToInt32(reader["percentage"]);
                    }
                    int quantity = -1;
                    if (reader["quantity"] != DBNull.Value)
                    {
                        quantity = Convert.ToInt32(reader["quantity"]);
                    }
                    int xAmount =-1;
                    if (reader["xAmount"] != DBNull.Value)
                    {
                        xAmount = Convert.ToInt32(reader["xAmount"]);
                    }

                    Category category;
                    if (categoryParent != -1)
                    {
                        category = new Category(categoryId, categoryName, categoryParent);
                    }
                    else
                    {
                        category = new Category(categoryId, categoryName);
                    }

                    Product product;
                    if (String.IsNullOrEmpty(unitExtension))
                    {
                        product = new Product(productId, category, productName, productPrice, inStock, unit, image, discontinued);
                    }
                    else
                    {
                        product = new Product(productId, category, productName, productPrice, inStock, unit, unitExtension, image, discontinued);
                    }
                    
                    if (typeOfBonus == BonusType.Percentage)
                    {
                        PercentageDiscount percentageDiscount = new PercentageDiscount(bonusId, product, startDate, endDate, bonusPrice, percentage);
                        bonuses.Add(percentageDiscount);
                    }
                    else if (typeOfBonus == BonusType.Quantity)
                    {
                        QuantityDiscount quantityDiscount = new QuantityDiscount(bonusId, product, startDate, endDate, bonusPrice, quantity);
                        bonuses.Add(quantityDiscount);
                    }
                    else if (typeOfBonus == BonusType.SecondHalfPrice)
                    {
                        SecondHalfPrice secondHalfPrice = new SecondHalfPrice(bonusId, product, startDate, endDate, bonusPrice);
                        bonuses.Add(secondHalfPrice);
                    }
                    else if (typeOfBonus == BonusType.XForY)
                    {
                        XForThePriceOfY xForY = new XForThePriceOfY(bonusId, product, startDate, endDate, bonusPrice, xAmount);
                        bonuses.Add(xForY);
                    }
                }

                return bonuses;
            }
        }
        catch (Exception ex)
        {
            
        }
        return  null!;
    }

    public void AddBonus(Bonuses bonus)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                if (bonus.GetType() == typeof(PercentageDiscount))
                {
                    PercentageDiscount percentageDiscount = (PercentageDiscount)bonus;
                    SqlCommand command = new SqlCommand("insert into Bonuses (ProductID, StartDate, EndDate, Price, TypeOfBonus, percentage) values (@ProductID, @StartDate, @EndDate, @Price, @TypeOfBonus, @Percentage)", connection);
                    command.Parameters.AddWithValue("@ProductID", percentageDiscount.Product.Id);
                    command.Parameters.AddWithValue("@StartDate", percentageDiscount.StartDate);
                    command.Parameters.AddWithValue("@EndDate", percentageDiscount.EndDate);
                    command.Parameters.AddWithValue("@Price", percentageDiscount.Price);
                    command.Parameters.AddWithValue("@TypeOfBonus", (int)BonusType.Percentage);
                    command.Parameters.AddWithValue("@Percentage", percentageDiscount.Percentage);
                    command.ExecuteNonQuery();
                }
                else if (bonus.GetType() == typeof(QuantityDiscount))
                {
                    QuantityDiscount quantityDiscount = (QuantityDiscount)bonus;
                    SqlCommand command = new SqlCommand("insert into Bonuses (ProductID, StartDate, EndDate, Price, TypeOfBonus, quantity) values (@ProductID, @StartDate, @EndDate, @Price, @TypeOfBonus, @Quantity)", connection);
                    command.Parameters.AddWithValue("@ProductID", quantityDiscount.Product.Id);
                    command.Parameters.AddWithValue("@StartDate", quantityDiscount.StartDate);
                    command.Parameters.AddWithValue("@EndDate", quantityDiscount.EndDate);
                    command.Parameters.AddWithValue("@Price", quantityDiscount.Price);
                    command.Parameters.AddWithValue("@TypeOfBonus", (int)BonusType.Quantity);
                    command.Parameters.AddWithValue("@Quantity", quantityDiscount.Quantity);
                    command.ExecuteNonQuery();
                }
                else if (bonus.GetType() == typeof(SecondHalfPrice))
                {
                    SecondHalfPrice secondHalfPrice = (SecondHalfPrice)bonus;
                    SqlCommand command = new SqlCommand("insert into Bonuses (ProductID, StartDate, EndDate, Price, TypeOfBonus) values (@ProductID, @StartDate, @EndDate, @Price, @TypeOfBonus)", connection);
                    command.Parameters.AddWithValue("@ProductID", secondHalfPrice.Product.Id);
                    command.Parameters.AddWithValue("@StartDate", secondHalfPrice.StartDate);
                    command.Parameters.AddWithValue("@EndDate", secondHalfPrice.EndDate);
                    command.Parameters.AddWithValue("@Price", secondHalfPrice.Price);
                    command.Parameters.AddWithValue("@TypeOfBonus", (int)BonusType.SecondHalfPrice);
                    command.ExecuteNonQuery();
                }
                else if (bonus.GetType() == typeof(XForThePriceOfY))
                {
                    XForThePriceOfY xForY = (XForThePriceOfY)bonus;
                    SqlCommand command = new SqlCommand("insert into Bonuses (ProductID, StartDate, EndDate, Price, TypeOfBonus, xAmount) values (@ProductID, @StartDate, @EndDate, @Price, @TypeOfBonus, @XAmount)", connection);
                    command.Parameters.AddWithValue("@ProductID", xForY.Product.Id);
                    command.Parameters.AddWithValue("@StartDate", xForY.StartDate);
                    command.Parameters.AddWithValue("@EndDate", xForY.EndDate);
                    command.Parameters.AddWithValue("@Price", xForY.Price);
                    command.Parameters.AddWithValue("@TypeOfBonus", (int)BonusType.XForY);
                    command.Parameters.AddWithValue("@XAmount", xForY.NumberOfItems);
                    command.ExecuteNonQuery();
                    
                }
            }
        }
        catch (Exception ex)
        {
            
        }
    }

    public void UpdateBonus(Bonuses bonus)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                if (bonus.GetType() == typeof(PercentageDiscount))
                {
                    PercentageDiscount percentageDiscount = (PercentageDiscount)bonus;
                    SqlCommand command = new SqlCommand("update Bonuses set StartDate = @StartDate, EndDate = @EndDate, Price = @Price, percentage = @Percentage where ID = @ID", connection);
                    command.Parameters.AddWithValue("@ID", percentageDiscount.Id);
                    command.Parameters.AddWithValue("@StartDate", percentageDiscount.StartDate);
                    command.Parameters.AddWithValue("@EndDate", percentageDiscount.EndDate);
                    command.Parameters.AddWithValue("@Price", percentageDiscount.Price);
                    command.Parameters.AddWithValue("@Percentage", percentageDiscount.Percentage);
                    command.ExecuteNonQuery();
                }
                else if (bonus.GetType() == typeof(QuantityDiscount))
                {
                    QuantityDiscount quantityDiscount = (QuantityDiscount)bonus;
                    SqlCommand command = new SqlCommand("update Bonuses set StartDate = @StartDate, EndDate = @EndDate, Price = @Price, quantity = @Quantity where ID = @ID", connection);
                    command.Parameters.AddWithValue("@ID", quantityDiscount.Id);
                    command.Parameters.AddWithValue("@StartDate", quantityDiscount.StartDate);
                    command.Parameters.AddWithValue("@EndDate", quantityDiscount.EndDate);
                    command.Parameters.AddWithValue("@Price", quantityDiscount.Price);
                    command.Parameters.AddWithValue("@Quantity", quantityDiscount.Quantity);
                    command.ExecuteNonQuery();
                }
                else if (bonus.GetType() == typeof(SecondHalfPrice))
                {
                    SecondHalfPrice secondHalfPrice = (SecondHalfPrice)bonus;
                    SqlCommand command = new SqlCommand("update Bonuses set StartDate = @StartDate, EndDate = @EndDate, Price = @Price where ID = @ID", connection);
                    command.Parameters.AddWithValue("@ID", secondHalfPrice.Id);
                    command.Parameters.AddWithValue("@StartDate", secondHalfPrice.StartDate);
                    command.Parameters.AddWithValue("@EndDate", secondHalfPrice.EndDate);
                    command.Parameters.AddWithValue("@Price", secondHalfPrice.Price);
                    command.ExecuteNonQuery();
                }
                else if (bonus.GetType() == typeof(XForThePriceOfY))
                {
                    XForThePriceOfY xForY = (XForThePriceOfY)bonus;
                    SqlCommand command = new SqlCommand("update Bonuses set StartDate = @StartDate, EndDate = @EndDate, Price = @Price, xAmount = @XAmount where ID = @ID", connection);
                    command.Parameters.AddWithValue("@ID", xForY.Id);
                    command.Parameters.AddWithValue("@StartDate", xForY.StartDate);
                    command.Parameters.AddWithValue("@EndDate", xForY.EndDate);
                    command.Parameters.AddWithValue("@Price", xForY.Price);
                    command.Parameters.AddWithValue("@XAmount", xForY.NumberOfItems);
                    command.ExecuteNonQuery();   
                }
            }
        }
        catch (Exception e)
        {
            
        }
    }

    public void DeleteBonus(Bonuses bonus)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("delete from Bonuses where BonusID = @BonusID", connection);
                command.Parameters.AddWithValue("@BonusID", bonus.Id);
                command.ExecuteNonQuery();
            }
            {
                
            }   
        }
        catch (Exception e)
        {
            
        }
    }
}