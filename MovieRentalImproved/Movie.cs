namespace MovieRentalImproved
{
    public abstract class Movie
    {

        public string Name { get; private set; }

        public abstract decimal CalculatePrice(TimeSpan rentalTime);

        public Movie(string name)
        {
            Name = name;
        }


    }
}
