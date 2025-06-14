public class Warrior : Character
{
    private int rage;
    public Warrior(string name) : base(name, 80)
    {
        rage = 20;
    }
    public override (int damage, string message) Attack()
    {
        if (!CanAttack())
            return (0, $"{Name} не может атаковать: недостаточно ярости!");
        rage -= 20;
        int damage = random.Next(20, 31);
        return (damage, $"{Name} нанес мощный удар, нанеся {damage} урона!");
    }
    public override bool CanAttack()
    {
        return rage >= 20;
    }
    public override void RestoreResource()
    {
        rage += 10;
    }
}

