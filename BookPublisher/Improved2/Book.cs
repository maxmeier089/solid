namespace BookPublisher.Improved2
{
    public class Book
    {

        public string Title { get; private set; }

        public string Author { get; private set; }


        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }

    }
}
