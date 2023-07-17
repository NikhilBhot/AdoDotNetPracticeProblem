
using Microsoft.Data.SqlClient;
using System.Data;

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
            //Get all customers details using ADO.Net framework.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Create the SQL query
                    string query = "SELECT * FROM Customers";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Create a data adapter to retrieve the data
                        SqlDataAdapter adapter = new SqlDataAdapter(command);

                        // Create a dataset to store the retrieved data
                        DataSet dataSet = new DataSet();

                        // Fill the dataset with the data from the adapter
                        adapter.Fill(dataSet, "Customers");

                        // Get the DataTable containing the customer data
                        DataTable customersTable = dataSet.Tables["Customers"];

                        // Iterate over the rows and display the customer details
                        foreach (DataRow row in customersTable.Rows)
                        {
                            Console.WriteLine("Customer ID: {0}", row["CustomerId"]);
                            Console.WriteLine("Name: {0}", row["Name"]);
                            Console.WriteLine("Email: {0}", row["Email"]);
                            Console.WriteLine("----------------------");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
            //Delete any one customer from database using ADO.Net framework.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Prompt user for customer ID to delete
                    Console.Write("Enter the Customer ID to delete: ");
                    int customerId = Convert.ToInt32(Console.ReadLine());

                    // Create the SQL query
                    string query = "DELETE FROM Customers WHERE CustomerId = @CustomerId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameter to the query
                        command.Parameters.AddWithValue("@CustomerId", customerId);

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Customer deleted successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Customer not found or deletion failed.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred: " + ex.Message);
                }
            }
            //Update customer salary based on customer name using ADO.Net framework.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Prompt user for customer name and new salary
                    Console.Write("Enter the customer name: ");
                    string customerName = Console.ReadLine();
                    Console.Write("Enter the new salary: ");
                    decimal newSalary = Convert.ToDecimal(Console.ReadLine());

                    // Create the SQL query
                    string query = "UPDATE Customers SET Salary = @Salary WHERE Name = @Name";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters to the query
                        command.Parameters.AddWithValue("@Name", customerName);
                        command.Parameters.AddWithValue("@Salary", newSalary);

                        // Execute the query
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Console.WriteLine("Customer salary updated successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Customer not found or update failed.");
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