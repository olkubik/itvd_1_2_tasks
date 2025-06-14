using System;

namespace CarManagement
{
    public struct Car
    {
        public string Brand;
        public string Model;
        public int Year;
        public string Color;
        public bool IsAvailable; // Логическое поле: true—доступен, false—продан/не используется

        public Car(string brand,string model,int year,string color)
        {
            Brand=brand;
            Model=model;
            Year=year;
            Color=color;
            IsAvailable = true;
        }

        public void PrintInfo(int index)
        {
            Console.WriteLine($"Автомобиль #{index}:");
            Console.WriteLine($"Марка: {Brand}");
            Console.WriteLine($"Модель: {Model}");
            Console.WriteLine($"Год выпуска: {Year}");
            Console.WriteLine($"Цвет: {Color}\n");
        }
    }

    class Program
    {
        static void InitializeCars(Car[] cars)
        {
            for (int i=0; i<cars.Length; i++)
            {
                cars[i].IsAvailable=false;
            }
        }

        static void FillWarehouse(Car[] cars)
        {
            for (int i=0; i<cars.Length; i++)
            {
                if (!cars[i].IsAvailable)
                {
                    Console.WriteLine($"Добавление автомобиля #{i + 1}:");
                    Console.Write("Марка: ");
                    string brand=Console.ReadLine();
                    Console.Write("Модель: ");
                    string model=Console.ReadLine();
                    Console.Write("Год выпуска: ");
                    int year=int.Parse(Console.ReadLine());
                    Console.Write("Цвет: ");
                    string color=Console.ReadLine();

                    cars[i]=new Car(brand, model, year, color);
                    cars[i].IsAvailable=true;
                    Console.WriteLine();
                }
            }
        }


        static void PrintAvailableCars(Car[] cars)
        {
            for (int i = 0; i < cars.Length; i++)
            {
                if (cars[i].IsAvailable)
                {
                    cars[i].PrintInfo(i + 1);
                }
            }
        }

        // Продажа автомобиля
        static void SellCar(Car[] cars)
        {
            Console.Write("Введите номер автомобиля для продажи: ");
            int index=int.Parse(Console.ReadLine()) - 1;

            if (index>=0 && index<cars.Length&&cars[index].IsAvailable)
            {
                cars[index].IsAvailable = false;
                Console.WriteLine("Автомобиль продан!");
            }
            else
            {
                Console.WriteLine("Ошибка: автомобиль не найден или уже продан.");
            }
        }

        static void Main()
        {
            Car[] cars = new Car[3]; 

            InitializeCars(cars);
            FillWarehouse(cars);
            PrintAvailableCars(cars);
            SellCar(cars);
            PrintAvailableCars(cars); // Проверка после продажи
        }
    }
}
