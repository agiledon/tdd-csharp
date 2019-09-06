using System;
using System.Data.SqlClient;

namespace Zhangyi.PracticeTDD.TDDBasic.OO.Template
{
    public abstract class DatabaseTemplate
    {
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

        protected abstract string BuildSQL();
        protected abstract void PopulateEntity(SqlDataReader reader);
    }
}