using System;
using System.Collections.Generic;
using Xunit;
using Zhangyi.PracticeTDD.MovieStore;

namespace MovieStore.Test
{
    public class StatementViewTest
    {
        private StatementView statementView;
        private const string NAME = "zhangyi";

        [Theory]
        [MemberData(nameof(CustomerFixture))]
        public void Should_statement(Customer customer, string expectedStatement)
        {
            statementView = new StatementView(customer);
            Assert.Equal(expectedStatement, statementView.Statement());
        }

        [Fact]
        public void Should_statement_for_many_rentals()
        {
            var customer = CreateCustomerWithTwoRentals();
            statementView = new StatementView(customer);

            var expectedStatement = "Rental Record for zhangyi\n\t" +
                                    "Brave Heart\t2\n\t" +
                                    "Iron Man\t12\n" +
                                    "Amount owed is 14\n" +
                                    "You earned 3 frequent renter points";

            Assert.Equal(expectedStatement, statementView.Statement());
        }

        public static IEnumerable<object[]> CustomerFixture()
        {
            yield return new object[] {CreateFrom(2, "Brave Heart", 0), BuildStatement("Brave Heart", 2.0, 2.0, 1) };
            yield return new object[] {CreateFrom(3, "Brave Heart", 0), BuildStatement("Brave Heart", 3.5, 3.5, 1) };
            yield return new object[] {CreateFrom(1, "Iron Man", 1), BuildStatement("Iron Man", 3.0, 3.0, 1) };
            yield return new object[] {CreateFrom(3, "Iron Man", 1), BuildStatement("Iron Man", 9.0, 9.0, 2) };
            yield return new object[] {CreateFrom(3, "Nezha", 2), BuildStatement("Nezha", 1.5, 1.5, 1) };
            yield return new object[] {CreateFrom(4, "Nezha", 2), BuildStatement("Nezha", 3.0, 3.0, 1) };
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

        private static Customer CreateCustomerWithTwoRentals()
        {
            var movie1 = new Movie("Brave Heart", 0);
            var movie2 = new Movie("Iron Man", 1);

            var rental1 = new Rental(movie1, 2);
            var rental2 = new Rental(movie2, 4);

            var customer = new Customer(NAME);
            customer.AddRental(rental1);
            customer.AddRental(rental2);
            return customer;
        }
    }
}