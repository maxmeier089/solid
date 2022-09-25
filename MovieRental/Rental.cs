namespace MovieRental
{
    public class Rental
    {

        public Movie Movie { get; private set; }

        public DateTime RentalStart { get; private set; }

        public decimal CalculatePrice(DateTime rentalEnd)
        {
            // compute time difference and round up to next full day
            int days = (int) Math.Ceiling((rentalEnd - RentalStart).TotalDays);

            decimal price = 0.0m;

            switch (Movie.MovieType)
            {
                case MovieType.Regular:

                    // 2.00 € base price for two days
                    price = 2.0m;

                    // 1.50 € for each additional day
                    if (days > 2) price += (days - 2) * 1.5m;
                    break;

                case MovieType.NewRelease:

                    // 3.00 € for each day
                    price += days * 3.0m;
                    break;

                case MovieType.Children:

                    // 1.50 € base price for three days
                    price = 1.5m;

                    // 1.00 € for each additional day
                    if (days > 3) price += (days - 3) * 1.0m;
                    break;
            }

            return price;
        }


        public Rental(Movie movie)
        {
            Movie = movie;
            RentalStart = DateTime.Now;
        }
    }
}
