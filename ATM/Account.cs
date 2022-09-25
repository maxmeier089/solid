namespace ATM
{
    public class Account
    {

        public string IBAN { get; private set; }

        public string Name { get; private set; }

        public decimal Balance { get; internal set; }

        public string PinHash { get; private set; }


        public Card CreateCard()
        {
            return new Card(IBAN);
        }

        public Account(string iban, string name, string pinHash)
        {
            IBAN = iban;
            Name = name;
            Balance = 0.0m;
            PinHash = pinHash;
        }

    }
}
