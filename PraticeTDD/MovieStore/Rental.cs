namespace Zhangyi.PracticeTDD.MovieStore
{
    public class Rental
    {
        private Movie movie;
        private int daysRented;

        public Rental(Movie movie, int daysRented)
        {
            this.movie = movie;
            this.daysRented = daysRented;
        }

        public int DaysRented => this.daysRented;

        public Movie Movie => this.movie;

        public int PointsFor(int frequentRenterPoints)
        {
            frequentRenterPoints++;

            if (Movie.PriceCode == Movie.NEW_RELEASE
                && DaysRented > 1)
            {
                frequentRenterPoints++;
            }
                
            return frequentRenterPoints;
        }

        public double AmountFor()
        {
            double thisAmount = 0;
            switch (Movie.PriceCode)
            {
                case Movie.REGULAR:
                    thisAmount += 2;
                    if (DaysRented > 2)
                        thisAmount += (DaysRented - 2) * 1.5;
                    break;
                case Movie.NEW_RELEASE:
                    thisAmount += DaysRented * 3;
                    break;
                case Movie.CHILDREN:
                    thisAmount += 1.5;
                    if (DaysRented > 3)
                        thisAmount += (DaysRented - 3) * 1.5;
                    break;
            }

            return thisAmount;
        }
    }
}