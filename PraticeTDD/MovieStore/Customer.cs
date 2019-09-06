﻿using System;
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

            totalAmount = TotalAmount(totalAmount);
            frequentRenterPoints = FrequentRenterPoints(frequentRenterPoints);

            foreach (var rental in rentals)
            {
                //show figures
                result += "\t" + rental.Movie.Title + "\t" + rental.AmountFor() + "\n";
            }

            //add footer lines
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints +
                    " frequent renter points";
            return result;
        }

        private int FrequentRenterPoints(int frequentRenterPoints)
        {
            foreach (var rental in rentals)
            {
                frequentRenterPoints += rental.PointsFor();
            }

            return frequentRenterPoints;
        }

        private double TotalAmount(double totalAmount)
        {
            foreach (var rental in rentals)
            {
                totalAmount += rental.AmountFor();
            }

            return totalAmount;
        }
    }
}
