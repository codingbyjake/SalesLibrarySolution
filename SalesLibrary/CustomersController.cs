using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesLibrary {
    public class CustomersController {

        private SqlConnection sqlConnection { get; set; }

        public List<Customer> GetBySalesRange(decimal low, decimal high) {
            var sql = "SELECT * FROM Customers " +
                       $"WHERE Sales >= {low} AND Sales <= {high} ORDER BY Sales DESC";
            var cmd = new SqlCommand(sql, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Customer> customers = new List<Customer>();
            while (reader.Read()) {
                Customer customer = new Customer();
                customer.Id = Convert.ToInt32(reader["Id"]);
                customer.Name = Convert.ToString(reader["Name"])!;
                customer.City = Convert.ToString(reader["City"])!;
                customer.State = Convert.ToString(reader["State"])!;
                customer.Sales = Convert.ToDecimal(reader["Sales"])!;
                customer.Active = Convert.ToBoolean(reader["Active"])!;
                customers.Add(customer);

            }
            reader.Close();
            return customers;

        }

        public List<Customer> GetAll() {
            var sql = "SELECT * FROM Customers;";
            var cmd = new SqlCommand(sql, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Customer> customers = new List<Customer>();
            while (reader.Read()) {
                Customer customer = new Customer();
                customer.Id = Convert.ToInt32(reader["Id"]);
                customer.Name = Convert.ToString(reader["Name"])!;
                customer.City = Convert.ToString(reader["City"])!;
                customer.State = Convert.ToString(reader["State"])!;
                customer.Sales = Convert.ToDecimal(reader["Sales"])!;
                customer.Active = Convert.ToBoolean(reader["Active"])!;
                customers.Add(customer);

            }
            reader.Close();
            return customers;
        }

        public Customer? GetById(int Id) {
            var sql = $"SELECT * FROM Customers WHERE ID = {Id};";
            var cmd = new SqlCommand(sql, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            if (!reader.HasRows) {
                reader.Close();
                return null;
            }
            reader.Read();
            Customer customer = new Customer();
            customer.Id = Convert.ToInt32(reader["Id"]);
            customer.Name = Convert.ToString(reader["Name"])!;
            customer.City = Convert.ToString(reader["City"])!;
            customer.State = Convert.ToString(reader["State"])!;
            customer.Sales = Convert.ToDecimal(reader["Sales"])!;
            customer.Active = Convert.ToBoolean(reader["Active"])!;
            reader.Close();
            return customer;
        }

        public bool Add(Customer cust) {
            var sql = "INSERT Customers ( Name, City, State, Sales, Active) VALUES " +
                      $"('{cust.Name}','{cust.City}','{cust.State}', {cust.Sales}, {(cust.Active ? 1 : 0)});";
            var cmd = new SqlCommand(sql, sqlConnection);
            var rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 0) {
                return false;
            }
            return true;
        }

        public bool Update(Customer cust) {
            var sql = "UPDATE Customers SET " +
                    $" Name = '{cust.Name}', " +
                    $" City = '{cust.City}', " +
                    $" State = '{cust.State}', " +
                    $" Sales = {cust.Sales}, " +
                    $" Active = {(cust.Active ? 1 : 0)} " +
                    $" WHERE Id = {cust.Id};";

            var cmd = new SqlCommand(sql, sqlConnection);
            var rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 0) {
                return false;
            }
            return true;
        }

        public bool Delete(int Id) {
            var sql = "DELETE Customers " +
                    $" WHERE Id = {Id};";
            Console.WriteLine(sql);
            var cmd = new SqlCommand(sql, sqlConnection);
            var rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 0) {
                return false;
            }

            return true;
        }

        public CustomersController(string server, string instance) {
            var connStr = $"server={server}\\{instance};" +
                            "database=SalesDb;" +
                            "trusted_connection=true;" +
                            "trustServerCertificate=true;";
            sqlConnection = new SqlConnection(connStr);
            sqlConnection.Open();
            if (sqlConnection.State != ConnectionState.Open) {
                throw new Exception("I screwed up my connection string!");
            }
            Console.WriteLine("Connection opened successfully!");
        }

        public void CloseConnection() {
            if (sqlConnection.State == System.Data.ConnectionState.Open) {
                sqlConnection.Close();
            }
        }



        //Practice Orders Table Connection

        public List<Order> GetAllOrders() {
            var sql = "SELECT * FROM Orders;";
            var cmd = new SqlCommand(sql, sqlConnection);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Order> orders = new List<Order>();
            while (reader.Read()) {
                Order order = new Order();
                order.Id = Convert.ToInt32(reader["Id"]);
                order.CustomerId = Convert.ToInt32(reader["CustomerId"]);
                order.Date = Convert.ToDateTime(reader["Date"])!;
                order.Description = Convert.ToString(reader["Description"])!;
                //order.Add(order);

            }
            reader.Close();
            return orders;
        }



        //^^^Practice Orders Table Connection^^^
    }

}
