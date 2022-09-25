namespace ATM
{
    public class Card
    {
        
        public string IBAN { get; private set; }

        public Card(string iban)
        {
            IBAN = iban;
        }

    }
}
