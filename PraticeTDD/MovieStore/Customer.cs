using System;
using System.Collections.Generic;
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
            double totalAmount = 0;
            int frequentRenterPoints = 0;
            string result = "Rental Record for " + name + "\n";

            foreach (Rental rental in rentals)
            {
                var thisAmount = AmountFor(rental);
                frequentRenterPoints = PointsFor(frequentRenterPoints, rental);

                //show figures
                result += "\t" + rental.Movie.Title + "\t" + thisAmount + "\n";
                totalAmount += thisAmount;
            }

            //add footer lines
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints +
                    " frequent renter points";
            return result;
        }

        private static int PointsFor(int frequentRenterPoints, Rental rental)
        {
            frequentRenterPoints++;

            if (rental.Movie.PriceCode == Movie.NEW_RELEASE
                && rental.DaysRented > 1)
            {
                frequentRenterPoints++;
            }
                
            return frequentRenterPoints;
        }

        private double AmountFor(Rental rental)
        {
            double thisAmount = 0;
            switch (rental.Movie.PriceCode)
            {
                case Movie.REGULAR:
                    thisAmount += 2;
                    if (rental.DaysRented > 2)
                        thisAmount += (rental.DaysRented - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:
                    thisAmount += rental.DaysRented * 3;
                    break;
                case Movie.CHILDREN:
                    thisAmount += 1.5;
                    if (rental.DaysRented > 3)
                        thisAmount += (rental.DaysRented - 3) * 1.5;
                    break;
            }

            return thisAmount;
        }
    }
}
