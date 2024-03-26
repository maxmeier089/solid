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
        public void Withdraw()
        {
            CreateLoginSequence();
            UserInput("2");
            ExpectMessage("How much money do you want do withdraw?");
            UserInput("55");
            ExpectMessage("Please take your money.");
            ExpectMessage("Your balance is: -55,00 €");
            CeateNothingElseSequence();

            ATM.InsertCard(Card);

            Assert.That(Account.Balance, Is.EqualTo(-55.0m));
        }

        [Test]
        public void Deposit()
        {
            Assert.That(Account.Balance, Is.EqualTo(0.0m));
        }

    }
}
