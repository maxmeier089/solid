using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMTest
{
    public class AccountTest : ATMTest
    {

        [Test]
        public void CreateAccount()
        {
            Assert.That(Account.IBAN, Is.EqualTo("DE12345"));
            Assert.That(Account.Name, Is.EqualTo("Franz Müller"));
            Assert.That(Account.Balance, Is.EqualTo(0.0m));
        }

        [Test]
        public void ShowBalance()
        {
            Assert.That(Account.Balance, Is.EqualTo(0.0m));

            InitialLogin();
            UserInput("1");
            ExpectDisplayBalance(0.0m);
            NothingElseRequired();

            ATM.InsertCard(Card);

            Assert.That(Account.Balance, Is.EqualTo(0.0m));
        }

        [Test]
        public void Withdraw()
        {
            Assert.That(Account.Balance, Is.EqualTo(0.0m));

            InitialLogin();
            UserInput("2");
            ExpectMessage("How much money do you want do withdraw?");
            UserInput("55");
            ExpectMessage("Please take your money.");
            ExpectDisplayBalance(-55.0m);
            NothingElseRequired();

            ATM.InsertCard(Card);

            Assert.That(Account.Balance, Is.EqualTo(-55.0m));
        }

        [Test]
        public void Deposit()
        {
            Assert.That(Account.Balance, Is.EqualTo(0.0m));

            InitialLogin();
            UserInput("3");
            ExpectMessage("How much money do you want do deposit?");
            UserInput("55");
            ExpectDisplayBalance(55.0m);
            NothingElseRequired();

            ATM.InsertCard(Card);

            Assert.That(Account.Balance, Is.EqualTo(55.0m));
        }

    }
}
