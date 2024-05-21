using OrdersAPI.Domain;
using System.Data;
using System.Data.SqlClient;

namespace OrdersAPI.Repositories
{
    internal class OrdersRepository
    {
        const string connectionString = "server=localhost; database=OrdersDB; integrated security=true;";

        public static List<Order> Select()
        {
            List<Order> orders = new List<Order>();

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                string query = "SELECT * FROM Orders";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Order order = new Order()
                    {
                        Id = Convert.ToInt32(sqlDataReader["id"]),
                        OrderNum = Convert.ToString(sqlDataReader["OrderNum"]),
                        OrderDate = Convert.ToDateTime(sqlDataReader["OrderDate"]),
                        CustomerId= Convert.ToInt32(sqlDataReader["CustomerId"]),
                        Total = Convert.ToDecimal(sqlDataReader["Total"])

                    };

                    orders.Add(order);

                }

            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }

            return orders;


        }

        public static void Insert(Order order)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                string query = $"INSERT INTO Orders (id, OrderNum, OrderDate, CustomerId, Total) VALUES ('{order.OrderNum}', '{order.OrderDate}', '{order.CustomerId}', '{order.Total}' )";

                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();

            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        public static void Update(Order order)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                string query = $"UPDATE Orders SET OrderNum = '{order.OrderNum}', OrderDate = '{order.OrderDate}', CustomerId = '{order.CustomerId}', Total = '{order.Total}' WHERE Id = '{order.Id}'";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }

        public static void Delete(int Id)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                string query = $"DELETE FROM Orders WHERE Id = {Id}";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }

            catch (SqlException exception)
            {
                Console.WriteLine(exception.Message);
            }

            finally
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
