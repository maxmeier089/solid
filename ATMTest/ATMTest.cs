﻿using ATM;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public void Setup()
        {
            ATM = new ATM.ATM();
            global::ATM.ATM.UI = this;

            Account = ATM.CreateAccount("DE12345", "Franz Müller", "4278");
            Card = Account.CreateCard();
        }


        private List<SequenceItem> expectedSequence = new List<SequenceItem>();


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

        protected void CreateLoginSequence()
        {
            NewSequence();
            ExpectMessage("Please enter your PIN!");
            UserInput("4278");
            ExpectMessage("PIN verified.");
            ExpectMessage("Welcome Franz Müller!");
            ExpectMessage("\nWhat do you want to do?");
            ExpectMessage("0: Exit\n1: Show Balance\n2: Withdraw\n3: Deposit\n4: Transfer");
        }

        protected void CeateNothingElseSequence()
        {
            ExpectMessage("\nDo you want to do something else?");
            ExpectMessage("0: Exit\n1: Show Balance\n2: Withdraw\n3: Deposit\n4: Transfer");
            UserInput("0");
            ExpectMessage("Bye!");
        }


        public void DisplayMessage(string message)
        {
            Assert.That(expectedSequence.Count, Is.GreaterThan(0));

            SequenceItem expectedItem = expectedSequence.First();
            expectedSequence.RemoveAt(0);

            Assert.That(expectedItem, Is.InstanceOf<MessageItem>());

            MessageItem outputItem = expectedItem as MessageItem;

            Assert.That(message, Is.Not.Null);

            Assert.That(message, Is.EqualTo(outputItem.Message));
        }

        public string ReadUserInput()
        {
            Assert.That(expectedSequence.Count, Is.GreaterThan(0));

            SequenceItem expectedItem = expectedSequence.First();
            expectedSequence.RemoveAt(0);

            Assert.That(expectedItem, Is.InstanceOf<InputItem>());

            InputItem inputItem = expectedItem as InputItem;

            return inputItem.Input;
        }

    }
}