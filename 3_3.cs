using System;

namespace ComplexNumbers
{
    public class Complex
    {
        public double Real {get;set;}
        public double Imaginary {get;set;}

        public Complex(double real, double imaginary)
        {
            Real=real;
            Imaginary=imaginary;
        }

        // Сложение
        public static Complex operator +(Complex a,Complex b)
        {
            return new Complex(a.Real+b.Real, a.Imaginary+b.Imaginary);
        }

        // Умножение
        public static Complex operator *(Complex a,Complex b)
        {
            return new Complex(
                a.Real*b.Real-a.Imaginary*b.Imaginary,
                a.Real*b.Imaginary+a.Imaginary*b.Real
            );
        }

        // Деление
        public static Complex operator /(Complex a, Complex b)
        {
            double denominator=b.Real*b.Real+b.Imaginary*b.Imaginary;
            if (denominator==0) throw new DivideByZeroException();
            return new Complex(
                (a.Real*b.Real+a.Imaginary*b.Imaginary)/denominator,
                (a.Imaginary*b.Real-a.Real*b.Imaginary)/denominator
            );
        }

        // Модуль
        public double Magnitude()
        {
            return Math.Sqrt(Real*Real+Imaginary*Imaginary);
        }

        // Аргумент (в радианах)
        public double Argument()
        {
            return Math.Atan2(Imaginary, Real);
        }

        // Возведение в степень (по формуле Муавра)
        public Complex Power(int exponent)
        {
            double magnitude=Math.Pow(Magnitude(), exponent);
            double angle=Argument()*exponent;
            return new Complex(
                magnitude*Math.Cos(angle),
                magnitude*Math.Sin(angle)
            );
        }

        // Извлечение корня (все n корней)
        public Complex[] Roots(int n)
        {
            if (n<=0) throw new ArgumentException("n должно быть>0");
            double magnitude=Math.Pow(Magnitude(), 1.0/n);
            double angle=Argument();
            Complex[] roots=new Complex[n];
            for (int k=0; k<n;k++)
            {
                double theta = (angle+2*Math.PI*k)/n;
                roots[k]=new Complex(
                    magnitude*Math.Cos(theta),
                    magnitude*Math.Sin(theta)
                );
            }
            return roots;
        }

        public override string ToString()
        {
            return $"{Real} {(Imaginary >= 0 ? "+" : "-")} {Math.Abs(Imaginary)}i";
        }
    }

    class Program
    {
        static void Main()
        {
            Complex a=new Complex(3,4);
            Complex b=new Complex(1,-2);

            Console.WriteLine($"a={a}");          
            Console.WriteLine($"b={b}\n");        

            Console.WriteLine($"a+b={a+b}");  
            Console.WriteLine($"a*b={a*b}");  
            Console.WriteLine($"a/b={a/b}");  
            Console.WriteLine($"|a|={a.Magnitude():F2}");  
            Console.WriteLine($"Аргумент a:{a.Argument():F2} рад\n");  

            Complex c = a.Power(2);
            Console.WriteLine($"a²={c}");         
            Console.WriteLine("\nКорни 3-й степени из 8:");
            Complex[] roots=new Complex(8, 0).Roots(3);
            foreach (var root in roots)
            {
                Console.WriteLine(root); 
            }
        }
    }
}