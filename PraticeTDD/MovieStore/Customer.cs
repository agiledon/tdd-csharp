using System.Collections.Generic;
using System.Linq;

namespace Zhangyi.PracticeTDD.MovieStore
{
    public class Customer
    {
        public IList<Rental> Rentals { get; } = new List<Rental>();

        public Customer(string name)
        {
            Name = name;
        }

        public void AddRental(Rental arg)
        {
            Rentals.Add(arg);
        }

        public string Name { get; }

        public int FrequentRenterPoints()
        {
            return Rentals.Sum(rental => rental.PointsFor());
        }

        public double TotalAmount()
        {
            return Rentals.Sum(rental => rental.AmountFor());
        }
    }
}
