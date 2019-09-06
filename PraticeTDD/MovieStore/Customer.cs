using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zhangyi.PracticeTDD.MovieStore
{
    public class Customer
    {
        private string name;
        public IList<Rental> Rentals { get; } = new List<Rental>();
        private readonly StatementView statementView;

        public Customer(string name)
        {
            this.name = name;
            statementView = new StatementView(this);
        }

        public void AddRental(Rental arg)
        {
            Rentals.Add(arg);
        }

        public string Name { get => this.name; }

        public StatementView StatementView
        {
            get { return statementView; }
        }

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
