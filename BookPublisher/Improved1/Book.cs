namespace BookPublisher.Improved1
{
    public class Book
    {

        public string Title { get; private set; }

        public string Author { get; private set; }


        private readonly BookPrinter printer;

        private readonly BookData data;


        public void Print()
        {
            BookPrinter.Print(this);
        }

        public void Save()
        {
            BookData.Save(this);
        }


        public Book(string title, string author)
        {
            Title = title;
            Author = author;
            printer = new BookPrinter();
            data = new BookData();
        }

    }
}
