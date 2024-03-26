using ATM;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ATMTest
{
    public abstract class ATMTest : IUserInterface
    {

        protected ATM.ATM ATM { get; private set; }

        protected Account Account { get; private set; }

        protected Card Card { get; private set;  }


        [SetUp]
        public virtual void Setup()
        {
            ATM = new ATM.ATM();
            global::ATM.ATM.UI = this;

            Account = ATM.CreateAccount("DE12345", "Franz Müller", "4278");
            Card = Account.CreateCard();
        }

        public void DisplayMessage(string message)
        {
            Assert.That(expectedSequence, Is.Not.Empty);

            SequenceItem expectedItem = expectedSequence.First();
            expectedSequence.RemoveAt(0);

            Assert.That(expectedItem, Is.InstanceOf<MessageItem>(), "Expected: " + expectedItem + " Actual: OUT " + message);

            MessageItem outputItem = expectedItem as MessageItem;

            Assert.That(message, Is.Not.Null);

            Assert.That(message, Is.EqualTo(outputItem.Message));
        }


        public string ReadUserInput()
        {
            Assert.That(expectedSequence, Is.Not.Empty);

            SequenceItem expectedItem = expectedSequence.First();
            expectedSequence.RemoveAt(0);

            Assert.That(expectedItem, Is.InstanceOf<InputItem>(), "Expected: " + expectedItem + " Actual: IN ");

            InputItem inputItem = expectedItem as InputItem;

            return inputItem.Input;
        }


        private readonly List<SequenceItem> expectedSequence = new();


        protected void ExpectMessage(string message)
        {
            expectedSequence.Add(new MessageItem(message));
        }

        protected void UserInput(string input)
        {
            expectedSequence.Add(new InputItem(input));
        }

        protected void NewSequence()
        {
            expectedSequence.Clear();
        }

        protected void InitialLogin()
        {
            NewSequence();
            ExpectMessage("Please enter your PIN!");
            EnterCorrectPIN();
        }

        protected void EnterCorrectPIN()
        {
            UserInput("4278");
            ExpectMessage("PIN verified.");
            ExpectMessage("Welcome Franz Müller!");
            ExpectMessage("\nWhat do you want to do?");
            ExpectMessage("0: Exit\n1: Show Balance\n2: Withdraw\n3: Deposit\n4: Transfer");
        }

        protected void ProcessShowBalance(decimal expectedBalance)
        {
            UserInput("1");
            ExpectDisplayBalance(expectedBalance);
            AskForSomethingElse();
        }


        protected void ProcessWithdraw(string input, decimal expectedBalance)
        {
            UserInput("2");
            ExpectMessage("How much money do you want do withdraw?");
            UserInput(input);
            ExpectMessage("Please take your money.");
            ExpectDisplayBalance(expectedBalance);
            AskForSomethingElse();
        }

        protected void ProcessDeposit(string input, decimal expectedBalance)
        {
            UserInput("3");
            ExpectMessage("How much money do you want do deposit?");
            UserInput(input);
            ExpectDisplayBalance(expectedBalance);
            AskForSomethingElse();
        }

        protected void AskForSomethingElse()
        {
            ExpectMessage("\nDo you want to do something else?");
            ExpectMessage("0: Exit\n1: Show Balance\n2: Withdraw\n3: Deposit\n4: Transfer");
        }

        protected void NothingElseRequired()
        {
            UserInput("0");
            ExpectMessage("Bye!");
        }

        protected void ExpectDisplayBalance(decimal balance)
        {
            ExpectMessage("Your balance is: " + String.Format(CultureInfo.CurrentCulture, "{0:c}", balance));
        }

    }
}
