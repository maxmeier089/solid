using MovieRentalImproved;

Movie movie1 = new RegularMovie("The Empire Strikes Back");
Movie movie2 = new NewMovie("Doctor Strange in the Multiverse of Madness");
Movie movie3 = new ChildrenMovie("The Jungle Book");

Console.OutputEncoding = System.Text.Encoding.UTF8;

static void printRentalPrice(Movie movie, double days)
{
    Rental rental = new(movie);

    DateTime rentalEnd = rental.RentalStart.AddDays(days);

    decimal price = rental.CalculatePrice(rentalEnd);

    Console.WriteLine(movie.Name + " rented for " + days + " days: " + String.Format("{0:c}", price));
}

printRentalPrice(movie1, 1);
printRentalPrice(movie1, 1.8);
printRentalPrice(movie1, 3.2);

Console.WriteLine();

printRentalPrice(movie2, 0.7);
printRentalPrice(movie2, 1.8);
printRentalPrice(movie2, 3.2);

Console.WriteLine();

printRentalPrice(movie3, 1.5);
printRentalPrice(movie3, 2.1);
printRentalPrice(movie3, 4.2);