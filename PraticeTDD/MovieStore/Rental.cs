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
    }
}