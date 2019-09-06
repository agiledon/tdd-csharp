namespace Zhangyi.PracticeTDD.MovieStore
{
    public class StatementView
    {
        private readonly Customer customer;

        public StatementView(Customer customer)
        {
            this.customer = customer;
        }

        public string Statement()
        {
            var result = "Rental Record for " + customer.Name + "\n";
            foreach (var rental in customer.Rentals)
            {
                //show figures
                result += "\t" + rental.Movie.Title + "\t" + rental.AmountFor() + "\n";
            }

            //add footer lines
            result += "Amount owed is " + customer.TotalAmount() + "\n";
            result += "You earned " + customer.FrequentRenterPoints() +
                      " frequent renter points";
            return result;
        }
    }
}