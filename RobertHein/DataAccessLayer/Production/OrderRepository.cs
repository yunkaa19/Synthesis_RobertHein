using Models.Entities;
using DataAccessLayer.Interfaces;
using System.Data.SqlClient;
using Models.Enums;

namespace DataAccessLayer.Production;

public class OrderRepository : Repository, IOrderRepository
{
    public List<Order> GetOrders(List<Product> allProducts, List<Customer> allCustomers, List<BonusCard> allBonusCards)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select o.id, orderdate, deliverydate, deliveryoption, customerid, bonuscardid, orderstatus, ProductID, Quantity from Orders as O join ProductsInOrder PIO on O.Id = PIO.OrderID", connection);
                SqlDataReader reader = command.ExecuteReader();
                List<Order> orders = new List<Order>();
                while (reader.Read())
                {
                    ShoppingCart shoppingCart = new ShoppingCart();
                    int orderId = Convert.ToInt32(reader["id"].ToString());
                    DateOnly orderDate = DateOnly.Parse(Convert.ToDateTime(reader["orderdate"].ToString()).ToShortDateString());
                    DateTime deliveryDate = Convert.ToDateTime(reader["deliverydate"].ToString());
                    DeliveryOptions deliveryOptions;
                    if(Convert.ToBoolean(reader["deliveryoption"].ToString()))
                    {
                        deliveryOptions = DeliveryOptions.PickUp;
                    }
                    else
                    {
                        deliveryOptions = DeliveryOptions.HomeDelivery;
                    }
                    Customer customer = allCustomers.Find(c => c.Id == Convert.ToInt32(reader["customerid"].ToString()));
                    BonusCard? bonusCard = allBonusCards.Find(b => b.CardNumber == reader["bonuscardid"].ToString());
                    bool orderStatus = Convert.ToBoolean(reader["orderstatus"].ToString());
                    int quantity = Convert.ToInt32(reader["Quantity"].ToString());
                    for(int i = 0; i < quantity; i++)
                    {
                        shoppingCart.AddItem(allProducts.Find(p => p.Id == Convert.ToInt32(reader["ProductID"].ToString())));
                    }

                    while (orderId == Convert.ToInt32(reader["id"].ToString()))
                    {
                        if (reader.Read())
                        {
                            quantity = Convert.ToInt32(reader["Quantity"].ToString());
                            for (int i = 0; i < quantity; i++)
                            {
                                shoppingCart.AddItem(allProducts.Find(p => p.Id == Convert.ToInt32(reader["ProductID"].ToString())));
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                    orders.Add(new Order(orderId, orderDate, deliveryDate, deliveryOptions, customer, bonusCard, shoppingCart, orderStatus));
                }
                return orders;
            }
        }
        catch (Exception ex)
        {
            
        }
        return null!;
    }
    

    public void AddOrder(Order order)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("insert into Orders (orderdate, deliverydate, deliveryoption, customerid, bonuscardid, orderstatus) values (@orderdate, @deliverydate, @deliveryoption, @customerid, @bonuscardid, @orderstatus)", connection);
                command.Parameters.AddWithValue("@orderdate", order.OrderDate);
                command.Parameters.AddWithValue("@deliverydate", order.DeliveryDate);
                command.Parameters.AddWithValue("@deliveryoption", order.DeliveryOption);
                command.Parameters.AddWithValue("@customerid", order.Customer.Id);
                command.Parameters.AddWithValue("@bonuscardid", order.BonusCard?.CardNumber);
                command.Parameters.AddWithValue("@orderstatus", order.OrderStatus);
                command.ExecuteNonQuery();
                command = new SqlCommand("select max(id) from Orders", connection);
                int orderId = Convert.ToInt32(command.ExecuteScalar().ToString());
                foreach (var item in order.ShoppingCart.CartItems.Select(x=>x).Distinct())
                {
                    command = new SqlCommand("insert into ProductsInOrder (OrderID, ProductID, Quantity) values (@orderid, @productid, @quantity)", connection);
                    command.Parameters.AddWithValue("@orderid", orderId);
                    command.Parameters.AddWithValue("@productid", item.Id);
                    command.Parameters.AddWithValue("@quantity", order.ShoppingCart.CartItems.Count(x => x.Id == item.Id));
                    command.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            
        }
    }

    public void UpdateOrder(Order order)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("update Orders set orderdate = @orderdate, deliverydate = @deliverydate, deliveryoption = @deliveryoption, customerid = @customerid, bonuscardid = @bonuscardid, orderstatus = @orderstatus where id = @id", connection);
                command.Parameters.AddWithValue("@orderdate", order.OrderDate);
                command.Parameters.AddWithValue("@deliverydate", order.DeliveryDate);
                command.Parameters.AddWithValue("@deliveryoption", order.DeliveryOption);
                command.Parameters.AddWithValue("@customerid", order.Customer.Id);
                command.Parameters.AddWithValue("@bonuscardid", order.BonusCard?.CardNumber);
                command.Parameters.AddWithValue("@orderstatus", order.OrderStatus);
                command.Parameters.AddWithValue("@id", order.Id);
                command.ExecuteNonQuery();
                SqlCommand UpdateProductsInOrder = new SqlCommand("delete from ProductsInOrder where OrderID = @orderid", connection);
                UpdateProductsInOrder.Parameters.AddWithValue("@orderid", order.Id);
                UpdateProductsInOrder.ExecuteNonQuery();
                foreach (var item in order.ShoppingCart.CartItems.Select(x => x).Distinct())
                {
                    command = new SqlCommand("insert into ProductsInOrder (OrderID, ProductID, Quantity) values (@orderid, @productid, @quantity)", connection);
                    command.Parameters.AddWithValue("@orderid", order.Id);
                    command.Parameters.AddWithValue("@productid", item.Id);
                    command.Parameters.AddWithValue("@quantity", order.ShoppingCart.CartItems.Count(x => x.Id == item.Id));
                    command.ExecuteNonQuery();
                }
                
            }   
        }
        catch (Exception ex)
        {
            
        }
    }

    public void DeleteOrder(int id)
    {
        try
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand("delete from Orders where id = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            
        }
    }
}