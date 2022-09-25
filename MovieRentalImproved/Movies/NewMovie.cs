namespace MovieRentalImproved
{
    public class NewMovie : Movie
    {

        public override decimal CalculatePrice(TimeSpan rentalTime)
        {
            // compute time difference and round up to next full day
            int days = (int)Math.Ceiling((rentalTime).TotalDays);

            decimal price = 0.0m;

            // 3.00 € for each day
            price += days * 3.0m;

            return price;
        }

        public NewMovie(string name) : base(name)
        {
        }

    }
}
