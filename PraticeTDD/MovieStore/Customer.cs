using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zhangyi.PracticeTDD.MovieStore
{
    public class Customer
    {
        private string name;
        private IList<Rental> rentals = new List<Rental>();

        public Customer(string name)
        {
            this.name = name;
        }

        public void AddRental(Rental arg)
        {
            rentals.Add(arg);
        }

        public string Name { get => this.name; }

        public string Statement()
        {
            string result = "Rental Record for " + name + "\n";
            foreach (var rental in rentals)
            {
                //show figures
                result += "\t" + rental.Movie.Title + "\t" + rental.AmountFor() + "\n";
            }

            //add footer lines
            result += "Amount owed is " + TotalAmount() + "\n";
            result += "You earned " + FrequentRenterPoints() +
                    " frequent renter points";
            return result;
        }

        private int FrequentRenterPoints()
        {
            return rentals.Sum(rental => rental.PointsFor());
        }

        private double TotalAmount()
        {
            return rentals.Sum(rental => rental.AmountFor());
        }
    }
}
