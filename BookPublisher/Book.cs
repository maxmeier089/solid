namespace BookPublisher
{
    public class Book
    {

        public string Title { get; private set; }

        public string Author { get; private set; }

        public void Print()
        {
            Console.WriteLine("Printing " + Title + " by " + Author);

            // pretend to print...
            Thread.Sleep(500);

            Console.WriteLine("Done!");
        }

        public void Save()
        {
            Console.WriteLine("Saving " + Title + " by " + Author);

            // pretend to save...
            Thread.Sleep(500);

            Console.WriteLine("Done!");
        }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }

    }
}
