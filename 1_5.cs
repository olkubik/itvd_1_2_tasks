using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    internal class Program
    {
    static void Main()
    {
        Console.WriteLine("стороны первого треугольника:");
        double a1 = double.Parse(Console.ReadLine());
        double b1 = double.Parse(Console.ReadLine());
        double c1 = double.Parse(Console.ReadLine());
        Console.WriteLine("стороны второго треугольника:");
        double a2 = double.Parse(Console.ReadLine());
        double b2 = double.Parse(Console.ReadLine());
        double c2 = double.Parse(Console.ReadLine());
        double[] t1 = new[] { a1, b1, c1 };
        double[] t2 = new[] { a2, b2, c2 };
        Array.Sort(t1);
        Array.Sort(t2);
        double r1 = t1[0] / t2[0];
        double r2 = t1[1] / t2[1];
        double r3 = t1[2] / t2[2];
        if (Math.Abs(r1 - r2) < 1e-6 && Math.Abs(r2 - r3) < 1e-6)
            Console.WriteLine("да");
        else
            Console.WriteLine("нет");
    }
}