using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    internal class Program
    {
    static void Main()
    {
        Console.Write("Введите x от -1 до 1: ");
        double x = double.Parse(Console.ReadLine());

        if (x < -1 || x > 1)
        {
            Console.WriteLine("Ошибка! x должен быть между -1 и 1");
            return;
        }

        double sum = 1.0;
        double term = 1.0;
        int n = 1;


        while (Math.Abs(term) >= 1e-6)
        {
            term *= x / n;
            sum += term;
            n++;
        }

        Console.WriteLine($"Приближение e^{x} = {sum:F6}");
        Console.WriteLine("Точное значение:   " + Math.Exp(x).ToString("F6"));
    }
}