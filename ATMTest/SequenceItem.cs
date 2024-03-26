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

        internal void CheckAction()
        {
            if (Action != null) Action();
        }

    }

    internal class MessageItem : SequenceItem
    {
        internal string Message { get; }

        internal MessageItem(string message)
        {
            Message = message;
        }
    }

    internal class InputItem : SequenceItem
    {
        internal string Input { get; }

        internal InputItem(string input)
        {
            Input = input;
        }
    }

}
