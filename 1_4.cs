using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    internal class Program
    {
    static void Main()
    {
        Console.Write("Введите первое число: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Введите второе число: ");
        int b = int.Parse(Console.ReadLine());
        Console.Write("Введите третье число: ");
        int c = int.Parse(Console.ReadLine());
        int res = 0;
        for (int i = 0; i < 32; i++)
        {
            int bitA = (a >> i) & 1;
            int bitB = (b >> i) & 1;
            int bitC = (c >> i) & 1;

            int sum = bitA + bitB + bitC;
            if (sum >= 2)
                res |= (1 << i);
        }
        Console.WriteLine("Результат:" + res);
    }
}