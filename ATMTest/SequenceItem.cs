using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMTest
{
    internal abstract class SequenceItem
    {
        internal Action? Action { get; set; }

        internal void InvokeAction()
        {
            Action?.Invoke();
        }

    }

    internal class MessageItem : SequenceItem
    {
        internal string Message { get; }

        public override string ToString()
        {
            return "MSG: " + Message;
        }

        internal MessageItem(string message)
        {
            Message = message;
        }
    }

    internal class InputItem : SequenceItem
    {
        internal string Input { get; }

        public override string ToString()
        {
            return "IN: " + Input;
        }

        internal InputItem(string input)
        {
            Input = input;
        }
    }

}
