namespace Zhangyi.PraticeTDD.MovieStore
{
    class Movie
    {
        public const int REGULAR = 0;
        public const int NEW_RELEASE = 1;
        public const int CHILDREN = 2;

        private readonly string title;
        private readonly int priceCode;

        public Movie(string title, int priceCode)
        {
            this.title = title;
            this.priceCode = priceCode;
        }

        public int PriceCode => this.priceCode;

        public string Title => this.title;
    }
}