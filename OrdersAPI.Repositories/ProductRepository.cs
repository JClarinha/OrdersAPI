using OrdersAPI.Domain;
using System.Data;
using System.Data.SqlClient;

namespace OrdersAPI.Repositories
{
    internal class ProductRepository
    {
        const string connectionString = "server=localhost; database=OrdersDB; integrated security=true;";

        public static List<Product> Select()
        {
            List<Product> products = new List<Product>();

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                string query = "SELECT * FROM Products";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Product product = new Product()
                    {
                        Id = Convert.ToInt32(sqlDataReader["Id"]),
                        Name = Convert.ToString(sqlDataReader["Name"]),
                        CategoryId = Convert.ToInt32(sqlDataReader["CategoryId"]),
                        UnitPrice = Convert.ToDecimal(sqlDataReader["UnitPrice"]),
                        Tax = Convert.ToInt32(sqlDataReader["Tax"]),
                        Unit = Convert.ToString(sqlDataReader["Unit"])

                    };

                    products.Add(product);

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

            return products;


        }

        public static void Insert(Product products)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                string query = $"INSERT INTO Products (Name, CategoryId, UnitPrice, Tax, Unit) VALUES ('{products.Name}', '{products.CategoryId}', '{products.UnitPrice}', '{products.Tax}', '{products.Unit}' )";

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

        public static void Update(Product product)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                string query = $"UPDATE Products SET Name = '{product.Name}', CategoryId = '{product.CategoryId}', UnitPrice = '{product.UnitPrice}', Tax = '{product.Tax}', '{product.Unit} WHERE Id = '{product.Id}'";
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
                string query = $"DELETE FROM Products WHERE Id = {Id}";
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
