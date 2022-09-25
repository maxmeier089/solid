namespace BookPublisher.Improved2
{
    public class BookPrinter
    {

        public static void Print(Book book)
        {
            Console.WriteLine("Printing " + book.Title + " by " + book.Author);

            // pretend to print...
            Thread.Sleep(500);

            Console.WriteLine("Done!");
        }

    }
}
