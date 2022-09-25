using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace ATM
{
    public class AutomaticTellerMachine
    {

        private readonly Dictionary<string, Account> accounts;


        public void InsertCard(Card card)
        {
            // get account
            if (card.IBAN == null)
            {
                Console.WriteLine("Unknown account.");
                return;
            }

            Account? account = accounts.GetValueOrDefault(card.IBAN);

            if (account == null)
            {
                Console.WriteLine("Unknown account.");
                return;
            }


            // check pin
            Console.WriteLine("Please enter your PIN!");

            int pinTries = 3; // max 3 tries

            while (true)
            {
                string? pinInput = Console.ReadLine();

                if (pinInput != null)
                {
                    string pinInputHash;

                    using (SHA256 hash = SHA256.Create())
                    {
                        pinInputHash = Encoding.UTF8.GetString(hash.ComputeHash(Encoding.UTF8.GetBytes(pinInput)));
                    }

                    if (pinInputHash == account.PinHash)
                    {
                        Console.WriteLine("PIN verified.");
                        break;
                    }
                }

                pinTries--;

                Console.WriteLine("Wrong PIN! " + pinTries + " tries left.");

                if (pinTries == 0)
                {
                    Console.WriteLine("3 wrong PINs entered.");
                    Console.WriteLine("Bye.");
                    return;
                }
            }


            // PIN ok!
            Console.WriteLine("Welcome " + account.Name + "!");

            // Perform tasks
            CheckWhatUserWantsToDo(account);
        }

        void CheckWhatUserWantsToDo(Account account)
        {
            Console.WriteLine("\nWhat do you want to do?");

            static void askIfUserWantsSomethingElse()
            {
                Console.WriteLine("\nDo you want to do something else? (y/n)");
            }

            while (true)
            {
                Console.WriteLine(
                    "0: Exit\n" +
                    "1: Show Balance\n" +
                    "2: Withdraw\n" +
                    "3: Deposit\n" +
                    "4: Transfer"
                    );

                string? input = Console.ReadLine();

                if (input == "0") break;
                else if (input == "1")
                {
                    ShowBalance(account);
                    askIfUserWantsSomethingElse();
                }
                else if (input == "2")
                {
                    Console.WriteLine("How much money do you want do withdraw?");

                    decimal amount = ReadAmount();

                    account.Balance -= amount;

                    Console.WriteLine("Please take your money.");

                    ShowBalance(account);

                    askIfUserWantsSomethingElse();
                }
                else if (input == "3")
                {
                    Console.WriteLine("How much money do you want do deposit?");

                    decimal amount = ReadAmount();

                    account.Balance += amount;

                    ShowBalance(account);

                    askIfUserWantsSomethingElse();
                }
                else if (input == "4")
                {
                    Account? targetAccount = null;

                    Console.WriteLine("Please enter the target account IBAN:");

                    while (targetAccount == null)
                    {
                        string? ibanInput = Console.ReadLine();

                        if (ibanInput != null)
                        {
                            targetAccount = accounts.GetValueOrDefault(ibanInput);
                        }

                        if (targetAccount == null) Console.WriteLine("Unknown IBAN!");
                    }

                    Console.WriteLine("How much money do you want to transfer?");

                    decimal amount = ReadAmount();

                    account.Balance -= amount;
                    targetAccount.Balance += amount;

                    Console.WriteLine("Transfer complete.");

                    ShowBalance(account);

                    askIfUserWantsSomethingElse();
                }
                else
                {
                    Console.WriteLine("Unknown input! (enter 0, 1, 2, 3)");
                }
            }

            Console.WriteLine("Bye!");
        }

        public Account CreateAccount(string iban, string name, string pin)
        {
            using SHA256 hash = SHA256.Create();
            string pinHash = Encoding.UTF8.GetString(hash.ComputeHash(Encoding.UTF8.GetBytes(pin)));
            Account account = new(iban, name, pinHash);
            accounts[account.IBAN] = account;
            return account;
        }

        public static void ShowBalance(Account account)
        {
            Console.WriteLine("Your balance is: " + String.Format(CultureInfo.CurrentCulture, "{0:c}", account.Balance));
        }

        static decimal ReadAmount()
        {
            while (true)
            {
                string? input = Console.ReadLine();

                if (decimal.TryParse(input, out decimal amount))
                {
                    return amount;
                }
                else
                {
                    Console.WriteLine("Please enter a number!");
                }
            }
        }

        public AutomaticTellerMachine()
        {
            accounts = new Dictionary<string, Account>();
        }

    }
}
