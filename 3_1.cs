using System;

namespace GeometryShapes
{
    public abstract class Shape
    {
        public abstract double Area();
        public abstract double Perimeter();
    }
    public class Circle : Shape
    {
        public double Radius {get;set;}

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double Area()
        {
            return Math.PI*Radius*Radius;
        }

        public override double Perimeter()
        {
            return 2*Math.PI*Radius;
        }
    }
    public class Rectangle:Shape
    {
        public double Length {get; set;}
        public double Width {get;set;}

        public Rectangle(double length, double width)
        {
            Length=length;
            Width=width;
        }

        public override double Area()
        {
            return Length*Width;
        }

        public override double Perimeter()
        {
            return 2*(Length+Width);
        }
    }
    public class Triangle:Shape
    {
        public double SideLength {get;set;}

        public Triangle(double sideLength)
        {
            SideLength=sideLength;
        }

        public override double Area()
        {
            return (Math.Sqrt(3)/4)*SideLength*SideLength;
        }

        public override double Perimeter()
        {
            return 3*SideLength;
        }
    }
    class Program
    {
        static void Main()
        {
            Circle circle=new Circle(5);
            Console.WriteLine($"Круг:Площадь={circle.Area():F2}, Длина окружности={circle.Perimeter():F2}");

            Rectangle rectangle=new Rectangle(4,6);
            Console.WriteLine($"Прямоугольник: Площадь={rectangle.Area()}, Периметр={rectangle.Perimeter()}");

            Triangle triangle=new Triangle(3);
            Console.WriteLine($"Треугольник: Площадь={triangle.Area():F2}, Периметр={triangle.Perimeter()}");
        }
    }
}
