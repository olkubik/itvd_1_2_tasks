using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    internal class Program
    {
    static void Main()
    {
        Console.Write(введите строку S: ");
        string s=Console.ReadLine();
        Console.Write("введите подстроку S1: ");
        string s1=Console.ReadLine();
        int count=0;
        for (int i=0; i<=s.Length-s1.Length;i++)
        {
            if (s.Substring(i,s1.Length)==s1)
                count++;
        }
        Console.WriteLine("количество вхождений: "+count);
    }
}
