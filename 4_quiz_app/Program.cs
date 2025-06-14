using System;

namespace _4_quiz_app
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Quiz App";
            Console.WriteLine("Тест по предмету\n");
            Console.WriteLine("Для каждого вопроса выберите номер ответа (1-4). Нажмите Enter, чтобы начать.");
            Console.ReadLine();
            Console.Clear();

            ConsoleManager consoleManager = new ConsoleManager();
            consoleManager.Start();
        }
    }
}
