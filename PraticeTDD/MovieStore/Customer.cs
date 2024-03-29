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

            foreach (Rental each in rentals)
            {
                double thisAmount = 0;
                //determine amounts for each line
                switch (each.Movie.PriceCode)
                {
                    case Movie.REGULAR:
                        thisAmount += 2;
                        if (each.DaysRented > 2)
                            thisAmount += (each.DaysRented - 2) * 1.5;
                        break;
                    case Movie.NEW_RELEASE:
                        thisAmount += each.DaysRented * 3;
                        break;
                    case Movie.CHILDREN:
                        thisAmount += 1.5;
                        if (each.DaysRented > 3)
                            thisAmount += (each.DaysRented - 3) * 1.5;
                        break;
                }
                // add frequent renter points
                frequentRenterPoints++;
                // add bonus for a two day new release rental
                if ((each.Movie.PriceCode == Movie.NEW_RELEASE)
                        &&
                        each.DaysRented > 1)
                    frequentRenterPoints++;
                //show figures
                result += "\t" + each.Movie.Title + "\t" + thisAmount + "\n";
                totalAmount += thisAmount;
            }

            //add footer lines
            result += "Amount owed is " + totalAmount + "\n";
            result += "You earned " + frequentRenterPoints +
                    " frequent renter points";
            return result;
        }
    }
}
