using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class ConsoleUserInterface : IUserInterface
    {

        public void DisplayMessage(string text)
        {
            Console.WriteLine(text);
        }

        public string ReadUserInput()
        {
            return Console.ReadLine() ?? "";
        }

    }
}
