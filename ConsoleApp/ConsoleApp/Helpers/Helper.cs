using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp.Helpers
{
    public static class Helper
    {
        public static void Print(ConsoleColor color,string message)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
