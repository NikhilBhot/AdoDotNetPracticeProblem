
using Microsoft.Data.SqlClient;

namespace ADODOTNetPracticeProblem
{
    public class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=RFP287;Integrated Security=True;";


            //Add customer details into customer table using ADO.Net framework.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();            

                    // Prompt user for customer details
                    Console.Write("Enter customer name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter customer email: ");
                    string email = Console.ReadLine();

                    // Create the SQL query
                    string query = "INSERT INTO Customers (Name, Email) VALUES (@Name, @Email)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the query
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Email", email);

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Customer details added successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Failed to add customer details.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
        }
    }
}