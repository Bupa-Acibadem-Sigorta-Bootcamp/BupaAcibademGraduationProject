using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthInsurance.EntityLayer.Concrete.Models;
using Microsoft.Data.SqlClient;

namespace HealthInsurance.DataAccessLayer.Concrete.ActiveDataObject.Net.Ado.NetRepository
{
    public class AdoNetProductRepository
    {
        readonly SqlConnection _connection =
            new SqlConnection(
                @"Server=YAHYAERDOGAN\SQLEXPRESS;Initial Catalog=BupaAcibademGraduation;Integrated Security=True");
        public List<Product> GetAll()
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Select * from Products", _connection);

            SqlDataReader reader = command.ExecuteReader();
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                Product product = new Product
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Title = reader["Title"].ToString(),
                    Price = Convert.ToInt32(reader["Price"])
                };
                products.Add(product);
            }
            reader.Close();
            _connection.Close();
            return products;
        }

        public void Add(Product product)
        {
            ConnectionControl();
            SqlCommand command = new SqlCommand("Insert Into Products values(@Title,@Price)", _connection);
            command.Parameters.AddWithValue("@Title", product.Title);
            command.Parameters.AddWithValue("@Price", product.Price);
            command.ExecuteNonQuery();
            _connection.Close();
        }


        private void ConnectionControl()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
        }
    }
}
