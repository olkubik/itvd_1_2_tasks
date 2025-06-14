using System;

namespace CustomNumber
{
    public struct Number
    {
        private double value;
        private bool isInteger;

        public Number(int num)
        {
            value=num;
            isInteger=true;
        }

        public Number(double num)
        {
            value=num;
            isInteger=false;
        }

        public static Number operator +(Number a, Number b)
        {
            return new Number(a.value+b.value)
            {
                isInteger=a.isInteger && b.isInteger
            };
        }

        public static Number operator -(Number a, Number b)
        {
            return new Number(a.value-b.value)
            {
                isInteger=a.isInteger && b.isInteger
            };
        }

        public static Number operator *(Number a, Number b)
        {
            return new Number(a.value*b.value)
            {
                isInteger=a.isInteger && b.isInteger
            };
        }

        public static Number operator /(Number a, Number b)
        {
            return new Number(a.value/b.value);
        }

        public static bool operator ==(Number a, Number b)
        {
            return a.value==b.value;
        }

        public static bool operator !=(Number a, Number b)
        {
            return !(a==b);
        }

        public static bool operator <(Number a, Number b)
        {
            return a.value<b.value;
        }

        public static bool operator >(Number a, Number b)
        {
            return a.value>b.value;
        }

        public static bool operator <=(Number a, Number b)
        {
            return a.value<=b.value;
        }

        public static bool operator >=(Number a, Number b)
        {
            return a.value>=b.value;
        }

        public override bool Equals(object obj)
        {
            return obj is Number number && this == number;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public override string ToString()
        {
            return isInteger ? ((int)value).ToString():value.ToString("F2");
        }
    }

    class Program
    {
        static void Main()
        {
            Number num1=new Number(5);
            Number num2=new Number(3.14);
            Number num3=new Number(2);

            Console.WriteLine($"Сложение: {num1+num2}");      
            Console.WriteLine($"Вычитание: {num1-num2}");     
            Console.WriteLine($"Умножение: {num1*num3}");     
            Console.WriteLine($"Деление: {num1/num3}");       

            Console.WriteLine($"Сравнение: {num1>num2}");     
            Console.WriteLine($"Равенство: {num1==num3}");    
        }
    }
}