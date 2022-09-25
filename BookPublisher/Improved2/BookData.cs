namespace BookPublisher.Improved2
{
    public class BookData
    {

        public static void Save(Book book)
        {
            Console.WriteLine("Saving " + book.Title + " by " + book.Author);

            // pretend to save...
            Thread.Sleep(500);

            Console.WriteLine("Done!");
        }

    }
}
