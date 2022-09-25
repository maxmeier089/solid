namespace MovieRental
{
    public class Movie
    {

        public string Name { get; private set; }

        public MovieType MovieType { get; private set; }

        public Movie(string name, MovieType movieType)
        {
            Name = name;
            MovieType = movieType;
        }

    }
}
