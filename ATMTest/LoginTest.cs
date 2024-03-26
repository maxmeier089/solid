using ATM;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System.Diagnostics.Metrics;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Security.Principal;

namespace ATMTest
{
    public class LoginTest : ATMTest
    {

        [Test]
        public void LoginSuccess()
        {
            Assert.That(Account.Balance, Is.EqualTo(0.0m));

            InitialLogin();
            UserInput("0");
            ExpectMessage("Bye!");

            ATM.InsertCard(Card);

            Assert.That(Account.Balance, Is.EqualTo(0.0m));
        }

        [Test]
        public void LoginFail()
        {
            NewSequence();
            ExpectMessage("Please enter your PIN!");
            UserInput("4275");
            ExpectMessage("Wrong PIN! 2 tries left.");
            UserInput("4272");
            ExpectMessage("Wrong PIN! 1 tries left.");
            UserInput("4273");
            ExpectMessage("Wrong PIN! 0 tries left.");
            ExpectMessage("3 wrong PINs entered.");
            ExpectMessage("Bye.");

            ATM.InsertCard(Card);
        }

        [Test]
        public void LoginAlmostFail()
        {
            NewSequence();
            ExpectMessage("Please enter your PIN!");
            UserInput("4275");
            ExpectMessage("Wrong PIN! 2 tries left.");
            UserInput("4272");
            ExpectMessage("Wrong PIN! 1 tries left.");
            EnterCorrectPIN();
            UserInput("0");
            ExpectMessage("Bye!");

            ATM.InsertCard(Card);
        }

        [Test]
        public void UnknownAccount()
        {
            NewSequence();
            ExpectMessage("Unknown account.");

            ATM.InsertCard(new Card("5401"));
        }

    }
}