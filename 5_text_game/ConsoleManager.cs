using System;



public class ConsoleManager
{
    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }

    public Character SelectCharacter()
    {
        DisplayMessage("Выберите класс персонажа:");
        DisplayMessage("1. Стрелок (Здоровье: 50, Урон: 15–20, Стрелы: 10)");
        DisplayMessage("2. Маг (Здоровье: 60, Урон: 10–25, Мана: 50)");
        DisplayMessage("3. Воин (Здоровье: 80, Урон: 10–15, Ярость: 20)");
        DisplayMessage("Введите номер (1–3): ");

        while (true)
        {
            string input = Console.ReadLine().Trim();
            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 3)
            {
                return choice switch
                {
                    1 => new Archer("Игрок-стрелок"),
                    2 => new Mage("Игрок-маг"),
                    3 => new Warrior("Игрок-воин"),
                    _ => throw new InvalidOperationException("Invalid choice")
                };
            }
            DisplayMessage("Пожалуйста, введите число от 1 до 3: ");
        }
    }

    public void DisplayBattleState(Character player, Character enemy)
    {
        Console.Clear();
        DisplayMessage($"=== Бой ===\n");
        DisplayMessage($"{player.Name}: Здоровье = {player.Health}/{player.MaxHealth}, Зелья лечения = {player.Inventory.HealingPotions}, Зелья ресурса = {player.Inventory.ResourcePotions}");
        if (player is Archer archer)
            DisplayMessage($"Стрелы: {archer.GetType().GetField("arrows", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(archer)}");
        else if (player is Mage mage)
            DisplayMessage($"Мана: {mage.GetType().GetField("mana", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(mage)}");
        else if (player is Warrior warrior)
            DisplayMessage($"Ярость: {warrior.GetType().GetField("rage", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(warrior)}");
        DisplayMessage($"{enemy.Name}: Здоровье = {enemy.Health}/{enemy.MaxHealth}");
        DisplayMessage("\n");
    }

    public string GetPlayerAction()
    {
        DisplayMessage("Выберите действие:");
        DisplayMessage("1. Атаковать");
        DisplayMessage("2. Использовать зелье лечения");
        DisplayMessage("3. Использовать зелье ресурса");
        DisplayMessage("Введите номер (1–3): ");

        while (true)
        {
            string input = Console.ReadLine().Trim();
            if (int.TryParse(input, out int choice) && choice >= 1 && choice <= 3)
            {
                return choice switch
                {
                    1 => "attack",
                    2 => "heal",
                    3 => "resource",
                    _ => throw new InvalidOperationException("Invalid action")
                };
            }
            DisplayMessage("Пожалуйста, введите число от 1 до 3: ");
        }
    }

    public bool AskToContinue()
    {
        DisplayMessage("Хотите продолжить и сразиться с новым противником? (y/n): ");
        while (true)
        {
            string input = Console.ReadLine().Trim().ToLower();
            if (input == "y") return true;
            if (input == "n") return false;
            DisplayMessage("Пожалуйста, введите 'y' или 'n': ");
        }
    }
    public void WaitForContinue()
    {
        DisplayMessage("Нажмите Enter для продолжения...");
        Console.ReadLine();
    }
}
