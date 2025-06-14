using System;


public class Game
{
    private Character player;
    private Character enemy;
    private int experience;
    private int level;
    private Random random;

    public Game()
    {
        experience = 0;
        level = 1;
        random = new Random();
    }

    public void Start(ConsoleManager consoleManager)
    {
        player = consoleManager.SelectCharacter();
        consoleManager.DisplayMessage($"Вы выбрали {player.Name} (Здоровье: {player.Health}, Уровень: {level})");

        while (true)
        {
            enemy = GenerateEnemy();
            consoleManager.DisplayMessage($"Ваш противник: {enemy.Name} (Здоровье: {enemy.Health})");
            bool playerWon = RunBattle(consoleManager);

            if (playerWon)
            {
                experience += 100;
                consoleManager.DisplayMessage($"Победа! Вы получили 100 XP. Текущий XP: {experience}");
                CheckLevelUp(consoleManager);
            }
            else
            {
                consoleManager.DisplayMessage("Поражение! Игра окончена.");
                break;
            }

            if (!consoleManager.AskToContinue())
                break;
            player.Health = player.MaxHealth;
        }
    }

    private Character GenerateEnemy()
    {
        int choice = random.Next(1, 4);
        return choice switch
        {
            1 => new Archer("Вражеский стрелок"),
            2 => new Mage("Вражеский маг"),
            3 => new Warrior("Вражеский воин"),
            _ => throw new InvalidOperationException("Invalid enemy type")
        };
    }

    private bool RunBattle(ConsoleManager consoleManager)
    {
        while (player.IsAlive && enemy.IsAlive)
        {
            consoleManager.DisplayBattleState(player, enemy);

            if (player.IsAlive)
            {
                string action = consoleManager.GetPlayerAction();
                if (action == "attack" && player.CanAttack())
                {
                    var (damage, message) = player.Attack();
                    consoleManager.DisplayMessage(message);
                    if (damage > 0)
                        enemy.Health -= damage;
                }
                else if (action == "attack" && !player.CanAttack())
                {
                    consoleManager.DisplayMessage("Невозможно атаковать! Используйте зелье ресурса.");
                }
                else if (action == "heal")
                {
                    bool used = player.Inventory.UseHealingPotion(player);
                    consoleManager.DisplayMessage(used ? $"{player.Name} использовал зелье лечения (+30 HP)." : "Нет зелий лечения!");
                }
                else if (action == "resource")
                {
                    bool used = player.Inventory.UseResourcePotion(player);
                    consoleManager.DisplayMessage(used ? $"{player.Name} использовал зелье ресурса." : "Нет зелий ресурса!");
                }
            }

            if (enemy.IsAlive && player.IsAlive)
            {
                if (enemy.CanAttack())
                {
                    var (damage, message) = enemy.Attack();
                    consoleManager.DisplayMessage(message);
                    if (damage > 0)
                        player.Health -= damage;
                }
                else
                {
                    bool used = enemy.Inventory.UseResourcePotion(enemy);
                    consoleManager.DisplayMessage(used ? $"{enemy.Name} использовал зелье ресурса." : $"{enemy.Name} не может атаковать и пропускает ход.");
                }
            }

            if (player.IsAlive && enemy.IsAlive)
            {
                consoleManager.WaitForContinue();
            }
        }

        return player.IsAlive;
    }

    private void CheckLevelUp(ConsoleManager consoleManager)
    {
        if (experience >= 200)
        {
            level++;
            experience -= 200;
            player.MaxHealth += 20;
            player.Health = player.MaxHealth;
            consoleManager.DisplayMessage($"Поздравляем! Вы достигли уровня {level}! Максимальное здоровье увеличено до {player.MaxHealth}.");
        }
    }
}
