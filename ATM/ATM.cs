using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace ATM
{
    public class ATM
    {

        public static IUserInterface UI { get; set; } = new ConsoleUserInterface();


        private readonly Dictionary<string, Account> accounts;


        public void InsertCard(Card card)
        {
            // get account
            if (card.IBAN == null)
            {
                ATM.UI.DisplayMessage("Unknown account.");
                return;
            }

            Account? account = accounts.GetValueOrDefault(card.IBAN);

            if (account == null)
            {
                ATM.UI.DisplayMessage("Unknown account.");
                return;
            }


            // check pin
            ATM.UI.DisplayMessage("Please enter your PIN!");

            int pinTries = 3; // max 3 tries

            while (true)
            {
                string? pinInput = ATM.UI.ReadUserInput();

                if (pinInput != null)
                {
                    string pinInputHash;

                    using (SHA256 hash = SHA256.Create())
                    {
                        pinInputHash = Encoding.UTF8.GetString(hash.ComputeHash(Encoding.UTF8.GetBytes(pinInput)));
                    }

                    if (pinInputHash == account.PinHash)
                    {
                        ATM.UI.DisplayMessage("PIN verified.");
                        break;
                    }
                }

                pinTries--;

                ATM.UI.DisplayMessage("Wrong PIN! " + pinTries + " tries left.");

                if (pinTries == 0)
                {
                    ATM.UI.DisplayMessage("3 wrong PINs entered.");
                    ATM.UI.DisplayMessage("Bye.");
                    return;
                }
            }


            // PIN ok!
            ATM.UI.DisplayMessage("Welcome " + account.Name + "!");

            // Perform tasks
            CheckWhatUserWantsToDo(account);
        }

        void CheckWhatUserWantsToDo(Account account)
        {
            ATM.UI.DisplayMessage("\nWhat do you want to do?");

            static void askIfUserWantsSomethingElse()
            {
                ATM.UI.DisplayMessage("\nDo you want to do something else?");
            }

            while (true)
            {
                ATM.UI.DisplayMessage(
                    "0: Exit\n" +
                    "1: Show Balance\n" +
                    "2: Withdraw\n" +
                    "3: Deposit\n" +
                    "4: Transfer"
                    );

                string? input = ATM.UI.ReadUserInput();

                if (input == "0") break;
                else if (input == "1")
                {
                    ShowBalance(account);
                    askIfUserWantsSomethingElse();
                }
                else if (input == "2")
                {
                    ATM.UI.DisplayMessage("How much money do you want do withdraw?");

                    decimal amount = ReadAmount();

                    account.Balance -= amount;

                    ATM.UI.DisplayMessage("Please take your money.");

                    ShowBalance(account);

                    askIfUserWantsSomethingElse();
                }
                else if (input == "3")
                {
                    ATM.UI.DisplayMessage("How much money do you want do deposit?");

                    decimal amount = ReadAmount();

                    account.Balance += amount;

                    ShowBalance(account);

                    askIfUserWantsSomethingElse();
                }
                else if (input == "4")
                {
                    Account? targetAccount = null;

                    ATM.UI.DisplayMessage("Please enter the target account IBAN:");

                    while (targetAccount == null)
                    {
                        string? ibanInput = ATM.UI.ReadUserInput();

                        if (ibanInput != null)
                        {
                            targetAccount = accounts.GetValueOrDefault(ibanInput);
                        }

                        if (targetAccount == null) ATM.UI.DisplayMessage("Unknown IBAN!");
                    }

                    ATM.UI.DisplayMessage("How much money do you want to transfer?");

                    decimal amount = ReadAmount();

                    account.Balance -= amount;
                    targetAccount.Balance += amount;

                    ATM.UI.DisplayMessage("Transfer complete.");

                    ShowBalance(account);

                    askIfUserWantsSomethingElse();
                }
                else
                {
                    ATM.UI.DisplayMessage("Unknown input! (enter 0, 1, 2, 3)");
                }
            }

            ATM.UI.DisplayMessage("Bye!");
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
            ATM.UI.DisplayMessage("Your balance is: " + String.Format(CultureInfo.CurrentCulture, "{0:c}", account.Balance));
        }

        static decimal ReadAmount()
        {
            while (true)
            {
                string? input = ATM.UI.ReadUserInput();

                if (decimal.TryParse(input, out decimal amount))
                {
                    return amount;
                }
                else
                {
                    ATM.UI.DisplayMessage("Please enter a number!");
                }
            }
        }

        public ATM()
        {
            accounts = new Dictionary<string, Account>();
        }

    }
}
