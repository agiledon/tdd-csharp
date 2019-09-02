﻿using System;
using System.Collections.Generic;
using Xunit;
using Zhangyi.PracticeTDD.MovieStore;

namespace MovieStore.Test
{
    public class CustomerTest
    {
        private const string NAME = "zhangyi";

        [Theory]
        [MemberData(nameof(CustomerFixture))]
        public void Should_statement(Customer customer, string expectedStatement)
        {
            Assert.Equal(expectedStatement, customer.Statement());
        }

        public static IEnumerable<object[]> CustomerFixture()
        {
            yield return new object[] {CreateFrom(2, "Brave Heart", 0), BuildStatement("Brave Heart", 2.0, 2.0, 1) };
            yield return new object[] {CreateFrom(3, "Brave Heart", 0), BuildStatement("Brave Heart", 3.5, 3.5, 1) };
            yield return new object[] {CreateFrom(1, "Iron Man", 1), BuildStatement("Iron Man", 3.0, 3.0, 1) };
            yield return new object[] {CreateFrom(3, "Iron Man", 1), BuildStatement("Iron Man", 9.0, 9.0, 2) };
            yield return new object[] {CreateFrom(3, "Nazha", 2), BuildStatement("Nazha", 1.5, 1.5, 1) };
            yield return new object[] {CreateFrom(4, "Nazha", 2), BuildStatement("Nazha", 3.0, 3.0, 1) };
        }

        private static string BuildStatement(string title, double amount, double totalAmounts, int points)
        {
            return
                $"Rental Record for {NAME}\n\t{title}\t{amount}\nAmount owed is {totalAmounts}\nYou earned {points} frequent renter points";
        }

        private static Customer CreateFrom(int daysRented, string title, int priceCode)
        {
            var movie = new Movie(title, priceCode);
            var rental = new Rental(movie, daysRented);
            var customer = new Customer(NAME);
            customer.AddRental(rental);
            return customer;
        }
    }
}