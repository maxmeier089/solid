using ATM;

ATM.ATM atm = new();

Account account1 = atm.CreateAccount("DE12345", "Franz Müller", "4278");
Card card1 = account1.CreateCard();

Account account2 = atm.CreateAccount("DE54321", "Lisa Huber", "3125");
Card card2 = account2.CreateCard();

Account account3 = atm.CreateAccount("DE98765", "Rudi Schmidt", "2143");
Card card3 = account3.CreateCard();

Console.OutputEncoding = System.Text.Encoding.UTF8;

while (true)
{
    Console.WriteLine("Please enter your card: (1, 2 or 3)");

    string? input = Console.ReadLine();

    Card? card = null;

    if (input == "0") break;
    else if (input == "1") card = card1;
    else if (input == "2") card = card2;
    else if (input == "3") card = card3;

    if (card != null)
    {
        atm.InsertCard(card);
    }
    else
    {
        Console.WriteLine("Unknown card! (enter 1, 2 or 3)");
    }

    Console.WriteLine();
}

Console.WriteLine("Bye!");
