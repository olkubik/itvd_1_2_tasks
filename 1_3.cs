using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    internal class Program
    {
    static void Main()
    {
        Console.Write("Введите a: ");
        double a = double.Parse(Console.ReadLine());
        Console.Write("Введите b: ");
        double b = double.Parse(Console.ReadLine());
        Console.Write("Введите c: ");
        double c = double.Parse(Console.ReadLine());
        if (a == 0 && b == 0)
        {
            Console.WriteLine(c == 0 ? "Бесконечно много решений" : "Нет решений");
        }
        else if (a == 0)
        {
            double x = -c / b;
            Console.WriteLine("Одно решение: x=" + x);
        }
        else
        {
            double d = b * b - 4 * a * c;
            if (d < 0)
                Console.WriteLine("Нет решений");
            else if (d == 0)
                Console.WriteLine("Одно решение: x = " + (-b / (2 * a)));
            else
            {
                double x1 = (-b + Math.Sqrt(d)) / (2 * a);
                double x2 = (-b - Math.Sqrt(d)) / (2 * a);
                Console.WriteLine("Два решения: x1 = " + x1 + ",x2= " + x2);
            }
        }
    }
}