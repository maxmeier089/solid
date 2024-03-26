using ATM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMTest
{
    public class CombinationTest : ATMTest
    {

        [Test]
        public void Combination1()
        {
            Assert.That(Account.Balance, Is.EqualTo(0.0m));

            InitialLogin();
            ProcessShowBalance(0.0m);
            ProcessDeposit("55", 55.0m);
            ProcessShowBalance(55.0m);
            ProcessWithdraw("55", 0.0m);
            ProcessShowBalance(0.0m);
            NothingElseRequired();

            ATM.InsertCard(Card);

            Assert.That(Account.Balance, Is.EqualTo(0.0m));
        }

    }
}
