using OrdersAPI.Domain;
using System.Data.SqlClient;
using System.Data;

namespace OrdersAPI.Repositories
{
    public class CustomerRepository
    {
        const string connectionString = "server=localhost; database=OrdersDB; integrated security=true;";

        public static List<Customer>  Select()
        {
            List<Customer> customers = new List<Customer>();

            SqlConnection sqlConnection = new SqlConnection (connectionString);

            try
            {
                string query = "SELECT * FROM Customers";
                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();

                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read()) 
                {
                    Customer customer = new Customer()
                    {
                        Id = Convert.ToInt32(sqlDataReader["Id"]),
                        Name = Convert.ToString(sqlDataReader["Name"]),
                        Nif = Convert.ToString(sqlDataReader["Nif"]),
                        Email = Convert.ToString(sqlDataReader["Email"]),
                        Phone = Convert.ToString(sqlDataReader["Phone"])
                  
                    };

                    customers.Add(customer);

                }

            }
            catch(SqlException exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            { 
                   if(sqlConnection.State == ConnectionState.Open) 
                      {
                    sqlConnection.Close(); 
                       }            
            }

            return customers;


        }

        public static void Insert(Customer customer)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                string query = "InsertCustomer";

              

                SqlParameter sqlParameterName = new SqlParameter
                {
                    Direction = ParameterDirection.Input,
                    ParameterName = "@Name",
                    Value = customer.Name,
                    DbType = DbType.String,


                };

                SqlParameter sqlParameterNif = new SqlParameter
                {
                    Direction = ParameterDirection.Input,
                    ParameterName = "@Nif",
                    Value = customer.Nif,
                    DbType = DbType.String,


                };

                SqlParameter sqlParameterEmail = new SqlParameter
                {
                    Direction = ParameterDirection.Input,
                    ParameterName = "@Email",
                    Value = customer.Email,
                    DbType = DbType.String,


                };

                SqlParameter sqlParameterPhone = new SqlParameter
                {
                    Direction = ParameterDirection.Input,
                    ParameterName = "@Phone",
                    Value = customer.Phone,
                    DbType = DbType.String,


                };

                

                SqlCommand sqlCommand = new SqlCommand(query,sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.Add(sqlParameterName);
                sqlCommand.Parameters.Add(sqlParameterNif);
                sqlCommand.Parameters.Add(sqlParameterEmail);
                sqlCommand.Parameters.Add(sqlParameterPhone);

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

        public static void Update(Customer customer)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                string query = $"UPDATE Customers SET Name = @Name, Nif = @Nif, Email = @Email, Phone = @Phone WHERE Id = @Id";


                SqlParameter sqlParameterName = new SqlParameter
                {
                    Direction = ParameterDirection.Input,
                    ParameterName = "@Name",
                    Value = customer.Name,
                    DbType = DbType.String,


                };

                SqlParameter sqlParameterNif = new SqlParameter
                {
                    Direction = ParameterDirection.Input,
                    ParameterName = "@Nif",
                    Value = customer.Nif,
                    DbType = DbType.String,


                };

                SqlParameter sqlParameterEmail = new SqlParameter
                {
                    Direction = ParameterDirection.Input,
                    ParameterName = "@Email",
                    Value = customer.Email,
                    DbType = DbType.String,


                };

                SqlParameter sqlParameterPhone = new SqlParameter
                {
                    Direction = ParameterDirection.Input,
                    ParameterName = "@Phone",
                    Value = customer.Phone,
                    DbType = DbType.String,


                };

                SqlParameter sqlParameterId = new SqlParameter
                {
                    Direction = ParameterDirection.Input,
                    ParameterName = "@Id",
                    Value = customer.Id,
                    DbType = DbType.String,


                };



                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

                sqlCommand.Parameters.Add(sqlParameterName);
                sqlCommand.Parameters.Add(sqlParameterNif);
                sqlCommand.Parameters.Add(sqlParameterEmail);
                sqlCommand.Parameters.Add(sqlParameterPhone);
                sqlCommand.Parameters.Add(sqlParameterId);

               
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
            SqlConnection sqlConnection = new SqlConnection( connectionString);

            try
            {
                string query = $"DELETE FROM Customers WHERE Id = {Id}";

                SqlParameter sqlParameterId = new SqlParameter
                {
                    Direction = ParameterDirection.Input,
                    ParameterName = "@Id",
                    Value = Id,
                    DbType = DbType.Int32,


                };



                SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

               
                sqlCommand.Parameters.Add(sqlParameterId);

                
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }

            catch(SqlException exception) 
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
