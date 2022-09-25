namespace MovieRentalImproved
{
    public class Rental
    {

        public Movie Movie { get; private set; }

        public DateTime RentalStart { get; private set; }

        public decimal CalculatePrice(DateTime rentalEnd)
        {
            return Movie.CalculatePrice(rentalEnd - RentalStart);
        }


        public Rental(Movie movie)
        {
            Movie = movie;
            RentalStart = DateTime.Now;
        }
    }
}
