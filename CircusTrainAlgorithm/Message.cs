using System;
using System.Collections.Generic;
using System.Text;

namespace CircusTrainAlgorithm
{
    public class Message
    {
        public static void ErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
