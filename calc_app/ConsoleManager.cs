using System;

namespace calc_app
{
    public class ConsoleManager
    {
        public void start()
        {
            Calculator calc = new Calculator();

            while (true)
            {
                string input = Console.ReadLine().Trim().ToLower();

                if (string.IsNullOrEmpty(input)) continue;

                if (input == "exit")
                {
                    Console.WriteLine("Выход из приложения...");
                    break;
                }

                if (input == "help")
                {
                    calc.help();
                    continue;
                }

                if (input == "clear")
                {
                    calc.Clear();
                    calc.GetResult();
                    continue;
                }

                if (input == "repeat")
                {
                    calc.RepeatLastOperation();
                    calc.GetResult();
                    continue;
                }

                if (input == "result")
                {
                    calc.GetResult();
                    continue;
                }

                if (input == "copy")
                {
                    calc.Copy();
                    continue;
                }

                if (input == "paste")
                {
                    calc.Paste();
                    calc.GetResult();
                    continue;
                }

                try
                {
                    string[] parts = input.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length != 3)
                    {
                        Console.WriteLine("Неверный ввод. Пример ввода: число операция число (\"2 + 3\")");
                        continue;
                    }

                    if (!double.TryParse(parts[0], out double num1) || !double.TryParse(parts[2], out double num2))
                    {
                        Console.WriteLine("Неверный формат чисел");
                        continue;
                    }

                    string operation = parts[1];
                    if (operation != "+" && operation != "-" && operation != "*" &&
                        operation != "/" && operation != "div" && operation != "mod")
                    {
                        Console.WriteLine("Неверная операция. Используйте +, -, *, /, div, mod");
                        continue;
                    }

                    calc.SetInitialValue(num1);

                    switch (operation)
                    {
                        case "+":
                            calc.Add(num2);
                            calc.GetResult();
                            break;
                        case "-":
                            calc.Subtract(num2);
                            calc.GetResult();
                            break;
                        case "*":
                            calc.Multiply(num2);
                            calc.GetResult();
                            break;
                        case "/":
                            calc.Divide(num2);
                            calc.GetResult();
                            break;
                        case "div":
                            calc.Div(num2);
                            calc.GetResult();
                            break;
                        case "mod":
                            calc.Mod(num2);
                            calc.GetResult();
                            break;
                    }
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("Ошибка выполнения операции");
                }

            }
        }
    }
}
