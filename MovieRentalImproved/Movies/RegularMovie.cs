namespace MovieRentalImproved
{
    public class RegularMovie : Movie
    {   

        public override decimal CalculatePrice(TimeSpan rentalTime)
        {
            // compute time difference and round up to next full day
            int days = (int)Math.Ceiling((rentalTime).TotalDays);

            // 2.00 € base price for two days
            decimal price = 2.0m;

            // 1.50 € for each additional day
            if (days > 2) price += (days - 2) * 1.5m;

            return price;
        }

        public RegularMovie(string name) : base(name)
        {
        }

    }
}
