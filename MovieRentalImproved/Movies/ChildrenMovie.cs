namespace MovieRentalImproved
{
    public class ChildrenMovie : Movie
    {   

        public override decimal CalculatePrice(TimeSpan rentalTime)
        {
            // compute time difference and round up to next full day
            int days = (int)Math.Ceiling((rentalTime).TotalDays);

            // 1.50 € base price for three days
            decimal price = 1.5m;

            // 1.00 € for each additional day
            if (days > 3) price += (days - 3) * 1.0m;

            return price;
        }

        public ChildrenMovie(string name) : base(name)
        {
        }

    }
}
