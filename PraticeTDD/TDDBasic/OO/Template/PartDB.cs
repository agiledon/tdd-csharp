using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Zhangyi.PracticeTDD.TDDBasic.OO.Template
{
    public class PartDb
    {
        private IList<Part> parts = new List<Part>();

        public void Populate()
        {
            const string connString = "Data Source=(local);Initial Catalog=Northwind;"
                                      + "Integrated Security=true";
            string queryString = BuildSQL();


            using (var connection = new SqlConnection(connString))
            {
                var command = new SqlCommand(queryString, connection);

                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        PopulateEntity(reader);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private string BuildSQL()
        {
            return "select * from part";
        }

        private void PopulateEntity(SqlDataReader reader)
        {
            var name = reader[0].ToString();
            var brand = reader[1].ToString();
            var retailPrice = double.Parse(reader[2].ToString());

            parts.Add(new Part(name, brand, retailPrice));
        }
    }

    class Part
    {
        private string name;
        private string brand;
        private double retailPrice;

        public Part(string name, string brand, double retailPrice)
        {
            this.name = name;
            this.brand = brand;
            this.retailPrice = retailPrice;
        }

        public string Name => name;

        public string Brand => brand;

        public double RetailPrice => retailPrice;
    }
}