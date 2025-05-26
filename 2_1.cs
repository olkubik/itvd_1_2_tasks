using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    internal class Program
    {
    static long FactIter(int n)
    {
        long res = 1;
        for (int i = 1; i <= n; i++)
        {
            res *= i;
        }
        return res;
    }


    static long FactRec(int n)
    {
        if (n == 0) return 1;
        return n * FactRec(n - 1);
    }


    static int FibIter(int n)
    {
        int a = 0, b = 1, temp;
        for (int i = 0; i < n; i++)
        {
            temp = a;
            a = b;
            b = temp + b;
        }
        return a;
    }

    static int FibRec(int n)
    {
        if (n <= 1) return n;
        return FibRec(n - 1) + FibRec(n - 2);
    }

    static void Main()
    {
        var sw = Stopwatch.StartNew();

        Console.WriteLine("Факториал 20 (итеративно): " + FactIter(20));
        Console.WriteLine("Рекурсия 15: " + FactRec(15));

        sw.Restart();
        var fact25 = FactRec(25);
        sw.Stop();
        Console.WriteLine("\nРекурсивно 25: " + sw.ElapsedMilliseconds + "ms");

        sw.Restart();
        FactIter(10000);
        sw.Stop();
        Console.WriteLine("Итеративно 10000: " + sw.ElapsedMilliseconds + "ms");

        Console.WriteLine("\nФибоначчи 30 (итеративно): " + FibIter(30));
        Console.WriteLine("Рекурсия 30: НЕ ЗАПУСКАТЬ - ЗАВИСНЕТ");
    }
}