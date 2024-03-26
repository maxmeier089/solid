using ATM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMTest
{
    public class TransferTest : ATMTest
    {

        Account OtherAccount { get; set; }

        Card OtherCard { get; set; }


        [SetUp]
        public override void Setup()
        {
            base.Setup();

            OtherAccount = ATM.CreateAccount("DE54321", "Lisa Huber", "3125");
            OtherCard = OtherAccount.CreateCard();
        }

        [Test]
        public void Transfer()
        {
            Assert.That(Account.Balance, Is.EqualTo(0.0m));
            Assert.That(OtherAccount.Balance, Is.EqualTo(0.0m));

            InitialLogin();
            UserInput("4");
            ExpectMessage("Please enter the target account IBAN:");
            UserInput("DE54321");
            ExpectMessage("How much money do you want to transfer?");
            UserInput("55");
            ExpectMessage("Transfer complete.");
            ExpectDisplayBalance(-55.0m);
            AskForSomethingElse();
            NothingElseRequired();

            ATM.InsertCard(Card);

            Assert.That(Account.Balance, Is.EqualTo(-55.0m));
            Assert.That(OtherAccount.Balance, Is.EqualTo(55.0m));
        }

    }
}
