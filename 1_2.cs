using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    internal class Program
    {
    static void Main()
    {
        Console.Write("Введите делимое(a): ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Введите делитель (b): ");
        int b = int.Parse(Console.ReadLine());

        int res = 0;
        int sum = b;

        if (a >= 0)
        {
            while (sum <= a)
            {
                res++;
                sum += b;
            }
        }
        else
        {
            while (sum <= -a)
            {
                res++;
                sum += b;
            }
            res = -res;
        }

        Console.WriteLine("Неполное частное: " + res);
    }
}