using System;

namespace calc_app
{
    public class Calculator
    {
        private double currentResult;
        private double lastNumber;
        private char lastOperation;
        private double clipboard;

        public Calculator()
        {
            currentResult = 0;
            lastNumber = 0;
            lastOperation = '\0';
            clipboard = 0;
        }
        public void help()
        {
            Console.WriteLine("help: вывод справки по командам \n" +
                "exit: выход из приложения \n" +
                "+: сложение \n" +
                "-: вычитание \n" +
                "*: умножение \n" +
                "/: деление \n" +
                "div: целочисленное деление \n" +
                "mod: остаток от деления \n" +
                "result: вывод текущего результата \n" +
                "clear: очистка текущего результата \n" +
                "repeat: повтор последней операции \n" +
                "copy: копирование текущего результата в буфер обмена \n" +
                "paste: вставка значения из буфера обмена \n"
                );
        }
        public void Add(double number)
        {
            currentResult += number;
            lastNumber = number;
            lastOperation = '+';
        }

        public void Subtract(double number)
        {
            currentResult -= number;
            lastNumber = number;
            lastOperation = '-';
        }

        public void Multiply(double number)
        {
            currentResult *= number;
            lastNumber = number;
            lastOperation = '*';
        }

        public void Divide(double number)
        {
            if (number == 0)
                throw new DivideByZeroException("Cannot divide by zero");
            currentResult /= number;
            lastNumber = number;
            lastOperation = '/';
        }

        public void Div(double number)
        {
            if (number == 0)
                throw new DivideByZeroException("Cannot divide by zero");
            currentResult = Math.Floor(currentResult / number);
            lastNumber = number;
            lastOperation = 'd';
        }

        public void Mod(double number)
        {
            if (number == 0)
                throw new DivideByZeroException("Cannot divide by zero");
            currentResult %= number;
            lastNumber = number;
            lastOperation = '%';
        }

        public void Clear()
        {
            currentResult = 0;
            lastNumber = 0;
            lastOperation = '\0';
        }

        public void GetResult()
        {
            Console.WriteLine($"Результат: {currentResult}\n");
        }

        public void RepeatLastOperation()
        {
            switch (lastOperation)
            {
                case '+':
                    Add(lastNumber);
                    break;
                case '-':
                    Subtract(lastNumber);
                    break;
                case '*':
                    Multiply(lastNumber);
                    break;
                case '/':
                    Divide(lastNumber);
                    break;
                case 'd':
                    Div(lastNumber);
                    break;
                case '%':
                    Mod(lastNumber);
                    break;
            }
        }

        public void Copy()
        {
            clipboard = currentResult;
        }

        public void Paste()
        {
            currentResult = clipboard;
        }

        public void SetInitialValue(double number)
        {
            currentResult = number;
        }
    }
}
