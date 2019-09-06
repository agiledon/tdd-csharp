using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Zhangyi.PracticeTDD.TDDBasic.OO.Template
{
    public class PartDb : DatabaseTemplate
    {
        private IList<Part> parts = new List<Part>();

        protected override string BuildSQL()
        {
            return "select * from part";
        }

        protected override void PopulateEntity(SqlDataReader reader)
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