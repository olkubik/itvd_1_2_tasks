using System;

namespace calc_app
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Calculator App";
            Console.WriteLine("Калькулятор\n");
            Console.WriteLine("Для справки введите: \"help\"");
            Console.WriteLine("Введите уравнение. Формат: число операция число (\"2 + 3\")\n");

            ConsoleManager consoleManager = new ConsoleManager();
            consoleManager.start();
        }
    }
}
