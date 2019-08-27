namespace Zhangyi.PraticeTDD.MovieStore
{
    class Rental
    {
        private Movie movie;
        private int daysRented;

        public Rental(Movie movie, int daysRented)
        {
            this.movie = movie;
            this.daysRented = daysRented;
        }

        public int DaysRented
        {
            get;
        }

        public Movie Movie
        {
            get;
        }
    }
}