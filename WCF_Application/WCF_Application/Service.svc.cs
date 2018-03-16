using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WCF_Application
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service.svc or Service.svc.cs at the Solution Explorer and start debugging.
    public class Service : IService
    {
        public CustomerData Get()
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT CustomerId, Name, Country FROM Customers"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            CustomerData customers = new CustomerData();
                            sda.Fill(customers.CustomersTable);
                            return customers;
                        }
                    }
                }
            }
        }

        public void Insert(string name, string country)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Customers (Name, Country) VALUES (@Name, @Country)"))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Country", country);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public void Update(int customerId, string name, string country)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("UPDATE Customers SET Name = @Name, Country = @Country WHERE CustomerId = @CustomerId"))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Country", country);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        public void Delete(int customerId)
        {
            string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Customers WHERE CustomerId = @CustomerId"))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }
    }
}
