public class Mage : Character
{
    private int mana;

    public Mage(string name) : base(name, 60)
    {
        mana = 50;
    }

    public override (int damage, string message) Attack()
    {
        if (!CanAttack())
            return (0, $"{Name} не может атаковать: закончилась мана!");
        mana -= 10;
        int damage = random.Next(10, 26);
        return (damage, $"{Name} запустил магический шар, нанеся {damage} урона!");
    }

    public override bool CanAttack()
    {
        return mana >= 10;
    }

    public override void RestoreResource()
    {
        mana += 20;
    }
}

